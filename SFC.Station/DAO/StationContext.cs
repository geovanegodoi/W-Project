using System.Data.Entity;

namespace SFC.Station.DAO
{
    public class StationContext : DbContext
    {
        public StationContext() : base("ConnectionStringName")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SchemaName");

            modelBuilder.Entity<Domain.Station>().ToTable("STATIONS");

            base.OnModelCreating(modelBuilder);
        }
    }
}
