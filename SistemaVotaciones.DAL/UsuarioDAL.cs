using SistemaVotaciones.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

public static class UsuarioDAL
{
    private static readonly string connectionString =
        "Data Source=DESKTOP-SJ108A6\\SQLEXPRESS;Initial Catalog=SistemaVotacionesBD;Integrated Security=True";

    // Verificar login
    public static bool ValidarCredenciales(string matricula, string password)
    {
        string query = "SELECT COUNT(*) FROM Usuarios WHERE Matricula = @Matricula AND Password = @Password";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            cmd.Parameters.AddWithValue("@Password", password);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }
    }

    // Saber si es administrador
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

    // Insertar nuevo usuario (con todos los campos del formulario)
    public static void InsertarUsuario(string matricula, string nombre, string password, bool esAdmin, string curso, string seccion)
    {
        string query = @"INSERT INTO Usuarios (Matricula, Nombre, Password, EsAdmin, Curso, Seccion) 
                         VALUES (@Matricula, @Nombre, @Password, @EsAdmin, @Curso, @Seccion)";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@EsAdmin", esAdmin);
            cmd.Parameters.AddWithValue("@Curso", curso);
            cmd.Parameters.AddWithValue("@Seccion", seccion);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // Obtener la plancha asignada a un usuario
    public static string ObtenerPlancha(string matricula)
    {
        string query = "SELECT Plancha FROM Usuarios WHERE Matricula = @Matricula";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            conn.Open();
            object result = cmd.ExecuteScalar();
            return result != null ? result.ToString() : "Ninguna";
        }
    }

    // Obtener el nombre de un usuario
    public static string ObtenerNombre(string matricula)
    {
        string query = "SELECT Nombre FROM Usuarios WHERE Matricula = @Matricula";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            conn.Open();
            object result = cmd.ExecuteScalar();
            return result != null ? result.ToString() : "Desconocido";
        }
    }

    // Eliminar usuario por matrícula
    public static void EliminarUsuario(string matricula)
    {
        string query = "DELETE FROM Usuarios WHERE Matricula = @Matricula";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public static Usuarios ObtenerUsuarioPorMatricula(string matricula)
    {
        string query = "SELECT * FROM Usuarios WHERE Matricula = @Matricula";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Usuarios
                    {
                        Matricula = reader["Matricula"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        Password = reader["Password"].ToString(),
                        Curso = reader["Curso"].ToString(),
                        Seccion = reader["Seccion"].ToString(),
                        EsAdmin = Convert.ToBoolean(reader["EsAdmin"])
                    };
                }
            }
        }
        return null;
    }
    public static void EliminarPlancha(string nombrePlancha)
    {
        string query = "DELETE FROM Planchas WHERE Nombre = @Nombre";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Nombre", nombrePlancha);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public static DataTable ObtenerResultados()
    {
        string query = "SELECT PlanchaId, COUNT(*) AS Votos FROM Votos GROUP BY PlanchaId";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public static void InsertarPlancha(string nombre, string presidente, string vice, string tesorero)
    {
        string query = "INSERT INTO Planchas (Nombre, Presidente, Vicepresidente, Tesorero) VALUES (@Nombre, @Presidente, @Vicepresidente, @Tesorero)";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Presidente", presidente);
            cmd.Parameters.AddWithValue("@Vicepresidente", vice);
            cmd.Parameters.AddWithValue("@Tesorero", tesorero);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public static void ActualizarPlancha(string nombre, string presidente, string vice, string tesorero)
    {
        string query = "UPDATE Planchas SET Presidente=@Presidente, Vicepresidente=@Vicepresidente, Tesorero=@Tesorero WHERE Nombre=@Nombre";
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Presidente", presidente);
            cmd.Parameters.AddWithValue("@Vicepresidente", vice);
            cmd.Parameters.AddWithValue("@Tesorero", tesorero);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public static string ValidarLogin(string matricula, string contraseña)
    {
        using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SJ108A6\\SQLEXPRESS;Initial Catalog=SistemaVotacionesBD;Integrated Security=True"))
        {
            string query = "SELECT Rol FROM Usuarios WHERE Matricula=@matricula AND Contraseña=@contraseña";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@matricula", matricula);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return result != null ? result.ToString() : null;
        }
    }

    public static bool RegistrarUsuario(string matricula, string nombre, string contraseña, string curso, string seccion)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            // 1. Verificar si ya existe la matrícula
            string checkQuery = "SELECT COUNT(*) FROM Usuarios WHERE Matricula=@Matricula";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@Matricula", matricula);

            conn.Open();
            int existe = (int)checkCmd.ExecuteScalar();

            if (existe > 0)
            {
                // Ya existe → no registrar
                return false;
            }

            // 2. Insertar nuevo usuario como votante
            string insertQuery = @"INSERT INTO Usuarios (Matricula, Nombre, Password, EsAdmin, Curso, Seccion, Rol) 
                               VALUES (@Matricula, @Nombre, @Password, 0, @Curso, @Seccion, 'Votante')";
            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
            insertCmd.Parameters.AddWithValue("@Matricula", matricula);
            insertCmd.Parameters.AddWithValue("@Nombre", nombre);
            insertCmd.Parameters.AddWithValue("@Password", contraseña);
            insertCmd.Parameters.AddWithValue("@Curso", curso);
            insertCmd.Parameters.AddWithValue("@Seccion", seccion);

            insertCmd.ExecuteNonQuery();
            return true;
        }
    }
}
