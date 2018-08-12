using System.Data.Entity;

namespace SFC.Route.DAO
{
    public class RouteContext : DbContext
    {
        public RouteContext() : base("ConnectionStringName")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SchemaName");

            modelBuilder.Entity<Domain.Route>().ToTable("ROUTES");

            base.OnModelCreating(modelBuilder);
        }
    }
}
