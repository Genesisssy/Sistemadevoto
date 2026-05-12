using System;
using System.Data.SqlClient;

public static class VotoDAL
{
    private static readonly string connectionString =
        @"Data Source=DESKTOP-SJ108A6\SQLEXPRESS;Initial Catalog=SistemaVotacionesBD;Integrated Security=True";

    /// <summary>
    /// Registra un voto en la tabla Votos.
    /// </summary>
    public static bool RegistrarVoto(int usuarioId, int? planchaId, bool esNulo = false)
    {
        try
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                string query = "INSERT INTO Votos (UsuarioId, PlanchaId, EsNulo) VALUES (@usuarioId, @planchaId, @esNulo)";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@usuarioId", usuarioId);

                    // 🔹 Si es voto nulo, guardamos NULL en PlanchaId
                    if (planchaId.HasValue)
                        comando.Parameters.AddWithValue("@planchaId", planchaId.Value);
                    else
                        comando.Parameters.AddWithValue("@planchaId", DBNull.Value);

                    comando.Parameters.AddWithValue("@esNulo", esNulo);

                    int filas = comando.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }
        catch (Exception ex)
        {
            // 🔹 Aquí puedes loguear el error si quieres depurar
            Console.WriteLine("Error en RegistrarVoto: " + ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Verifica si un usuario ya ha votado.
    /// </summary>
    public static bool YaVoto(int usuarioId)
    {
        string query = "SELECT COUNT(*) FROM Votos WHERE UsuarioId = @usuarioId";
        using (SqlConnection conexion = new SqlConnection(connectionString))
        using (SqlCommand comando = new SqlCommand(query, conexion))
        {
            comando.Parameters.AddWithValue("@usuarioId", usuarioId);
            conexion.Open();
            int cantidad = Convert.ToInt32(comando.ExecuteScalar());
            return cantidad > 0;
        }
    }
}
