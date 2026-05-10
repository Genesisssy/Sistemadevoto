using System.Data.Entity;

namespace SistemaVotaciones.Entidades
{
    public partial class SitemaVotacioneDBEntities : DbContext
    {
        public SitemaVotacioneDBEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}
