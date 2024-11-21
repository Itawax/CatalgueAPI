using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models    
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext(DbContextOptions<CatalogueContext> options)
        : base(options)
        {
        }

        public CatalogueContext()
        {
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Catalogue;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public DbSet<CatalogueItem> CatalogueItems { get; set; } = null!;
    }
}
