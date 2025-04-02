using Microsoft.EntityFrameworkCore;

namespace Novaula.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options) {}

        public DbSet<models.Pivete> pivetes {get; set;}
    }
}