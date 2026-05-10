using System;
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
}
