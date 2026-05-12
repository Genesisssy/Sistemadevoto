using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaVotacionesFINAL
{
    public static class UsuarioDAL
    {
        // 🔹 Cadena de conexión única
        private static readonly string connectionString =
            "Data Source=DESKTOP-SJ108A6\\SQLEXPRESS;Initial Catalog=SistemaVotacionesBD;Integrated Security=True";

        // ------------------ MÉTODOS DE AUTENTICACIÓN ------------------

        public static int ValidarUsuario(string matricula, string password)
        {
            string query = "SELECT Id FROM Usuarios WHERE Matricula = @Matricula AND Password = @Password";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Matricula", matricula);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        public static string ObtenerRol(string matricula)
        {
            string query = "SELECT Rol FROM Usuarios WHERE Matricula = @Matricula";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Matricula", matricula);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "Votante";
            }
        }

        // ------------------ GESTIÓN DE USUARIOS ------------------

        public static bool RegistrarUsuario(string matricula, string nombre, string password, string curso, string seccion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Verificar duplicado
                string checkQuery = "SELECT COUNT(*) FROM Usuarios WHERE Matricula = @Matricula";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Matricula", matricula);
                    if ((int)checkCmd.ExecuteScalar() > 0) return false;
                }

                // Insertar nuevo usuario
                string insertQuery = @"INSERT INTO Usuarios (Matricula, Nombre, Password, Curso, Seccion, Rol, EsAdmin) 
                                       VALUES (@Matricula, @Nombre, @Password, @Curso, @Seccion, 'Votante', 0)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@Matricula", matricula);
                    insertCmd.Parameters.AddWithValue("@Nombre", nombre);
                    insertCmd.Parameters.AddWithValue("@Password", password);
                    insertCmd.Parameters.AddWithValue("@Curso", curso);
                    insertCmd.Parameters.AddWithValue("@Seccion", seccion);
                    return insertCmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool EliminarUsuario(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuarios WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public static Usuario ObtenerUsuarioPorMatricula(string matricula)
        {
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuarios WHERE Matricula = @Matricula";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Matricula", matricula);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Matricula = reader["Matricula"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Curso = reader["Curso"].ToString(),
                        Seccion = reader["Seccion"].ToString(),
                        Password = reader["Password"].ToString(),
                        Rol = reader["Rol"].ToString()
                    };
                }
            }

            return usuario;
        }

        public static bool ActualizarUsuario(string matricula, string nombre, string password, string curso, string seccion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Usuarios 
                                 SET Nombre = @Nombre, Password = @Password, Curso = @Curso, Seccion = @Seccion 
                                 WHERE Matricula = @Matricula";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Curso", curso);
                cmd.Parameters.AddWithValue("@Seccion", seccion);
                cmd.Parameters.AddWithValue("@Matricula", matricula);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

        // ------------------ MÉTODOS PARA VOTOS ------------------

        public static bool RegistrarVoto(int usuarioId, int planchaId, bool esNulo)
        {
            if (usuarioId <= 0)
                throw new Exception("Error: el ID del usuario no es válido.");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Votos (UsuarioId, PlanchaId, EsNulo, Fecha) VALUES (@UsuarioId, @PlanchaId, @EsNulo, @Fecha)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                cmd.Parameters.AddWithValue("@PlanchaId", planchaId);
                cmd.Parameters.AddWithValue("@EsNulo", esNulo);
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }


        public static bool YaVoto(int usuarioId)
        {
            string query = "SELECT COUNT(*) FROM Votos WHERE UsuarioId = @UsuarioId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public static DataTable ObtenerResultados()
        {
            string query = @"SELECT P.Nombre AS Plancha, COUNT(V.Id) AS TotalVotos 
                             FROM Planchas P 
                             LEFT JOIN Votos V ON P.Id = V.PlanchaId 
                             GROUP BY P.Nombre";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ------------------ MÉTODOS AUXILIARES ------------------

        public static string ObtenerPlancha(string matricula)
        {
            string query = "SELECT Plancha FROM Usuarios WHERE Matricula = @Matricula";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Matricula", matricula);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "Ninguna";
            }
        }

        public static string ObtenerNombre(string matricula)
        {
            string query = "SELECT Nombre FROM Usuarios WHERE Matricula = @Matricula";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Matricula", matricula);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "Usuario";
            }
        }

        public static bool EsAdministrador(string matricula)
        {
            string query = "SELECT EsAdmin FROM Usuarios WHERE Matricula = @Matricula";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Matricula", matricula);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null && Convert.ToBoolean(result);
            }
        }

        // ------------------ CLASE AUXILIAR ------------------

        public class Usuario
        {
            public int Id { get; set; }
            public string Matricula { get; set; }
            public string Nombre { get; set; }
            public string Curso { get; set; }
            public string Seccion { get; set; }
            public string Password { get; set; }
            public string Rol { get; set; }
        }

        public static bool InsertarPlancha(string nombre, string presidente, string vice, string tesorero, string secretario)
        {
            string query = @"INSERT INTO Planchas (Nombre, Presidente, Vicepresidente, Tesorero, Secretario) 
                     VALUES (@Nombre, @Presidente, @Vicepresidente, @Tesorero, @Secretario)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Presidente", presidente);
                cmd.Parameters.AddWithValue("@Vicepresidente", vice);
                cmd.Parameters.AddWithValue("@Tesorero", tesorero);
                cmd.Parameters.AddWithValue("@Secretario", secretario);

                conn.Open();
                int filas = cmd.ExecuteNonQuery();
                return filas > 0;
            }
        }

    }
}