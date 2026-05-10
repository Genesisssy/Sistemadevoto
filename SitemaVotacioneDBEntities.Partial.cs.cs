using System.Data.Entity;

namespace SistemaVotaciones.Entidades
{
    public partial class SitemaVotacioneDBEntities : DbContext
    {
        // Constructor que recibe la cadena de conexión directamente
        public SitemaVotacioneDBEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}