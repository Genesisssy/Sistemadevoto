using System.Data.SqlClient;

namespace SistemaVotacionesFINAL
{
    public static class ConexionDAL
    {
        // 🔹 Conexión usando autenticación de Windows
        public static string CadenaConexion =
            "Data Source=DESKTOP-SJ108A6\\SQLEXPRESS;Initial Catalog=SistemaVotacionesBD;Integrated Security=True";

        // 🔹 Si usas autenticación de SQL Server (usuario y contraseña), comenta la anterior y usa esta:
        // public static string CadenaConexion =
        //     "Data Source=DESKTOP-SJ108A6\\SQLEXPRESS;Initial Catalog=SistemaVotacionesBD;User ID=tuUsuario;Password=tuContraseña";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }
        public static (int, string) ValidarUsuarioConRol(string nombreUsuario, string contraseña)
        {
            using (SqlConnection conexion = ConexionDAL.ObtenerConexion())
            {
                conexion.Open();

                string query = "SELECT Id, Rol FROM Usuarios WHERE NombreUsuario=@usuario AND Contraseña=@contraseña";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@usuario", nombreUsuario);
                comando.Parameters.AddWithValue("@contraseña", contraseña);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string rol = reader.GetString(1);
                    return (id, rol);
                }
                else
                {
                    return (-1, null);
                }
            }
        }

    }
}


