using System;
using System.Data;
using System.Data.SqlClient;

public static class UsuarioDAL
{
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
            return result?.ToString();
        }
    }

    // ------------------ GESTIÓN DE USUARIOS ------------------

    public static bool RegistrarUsuario(string matricula, string nombre, string password, string curso, string seccion)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string checkQuery = "SELECT COUNT(*) FROM Usuarios WHERE Matricula = @Matricula";
            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@Matricula", matricula);
                if ((int)checkCmd.ExecuteScalar() > 0) return false;
            }

            string insertQuery = @"INSERT INTO Usuarios (Matricula, Nombre, Password, EsAdmin, Curso, Seccion, Rol) 
                                 VALUES (@Matricula, @Nombre, @Password, 0, @Curso, @Seccion, 'Votante')";

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
        using (SqlConnection conn = new SqlConnection(cadenaConexion))
        {
            string query = "DELETE FROM Usuarios WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            int filas = cmd.ExecuteNonQuery();
            return filas > 0;
        }

    }

    private static string cadenaConexion =
 @"Server=DESKTOP-SJ108A6\SQLEXPRESS;Database=SistemaVotaciones;Trusted_Connection=True;";





    // ------------------ GESTIÓN DE PLANCHAS ------------------

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


    public static bool EliminarPlancha(string nombrePlancha)
    {
        string query = "DELETE FROM Planchas WHERE Nombre = @Nombre";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Nombre", nombrePlancha);
            conn.Open();
            int filas = cmd.ExecuteNonQuery();
            return filas > 0;
        }
    }

    // ------------------ MÉTODOS PARA VOTOS ------------------

    public static void RegistrarVoto(int usuarioId, int planchaId, bool esNulo)
    {
        if (usuarioId <= 0)
            throw new Exception("Error: el ID del usuario no es válido.");

        using (SqlConnection conexion = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Votos (UsuarioId, PlanchaId, EsNulo, Fecha) VALUES (@usuarioId, @planchaId, @esNulo, @fecha)";
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@usuarioId", usuarioId);
                comando.Parameters.AddWithValue("@planchaId", planchaId);
                comando.Parameters.AddWithValue("@esNulo", esNulo);
                comando.Parameters.AddWithValue("@fecha", DateTime.Now);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }
    }

    public static bool YaVoto(int usuarioId)
    {
        string query = "SELECT COUNT(*) FROM Votos WHERE UsuarioId = @usuarioId";
        using (SqlConnection conexion = new SqlConnection(connectionString))
        using (SqlCommand comando = new SqlCommand(query, conexion))
        {
            comando.Parameters.AddWithValue("@usuarioId", usuarioId);
            conexion.Open();
            return (int)comando.ExecuteScalar() > 0;
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
}