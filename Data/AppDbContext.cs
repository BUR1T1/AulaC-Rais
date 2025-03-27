using Microsoft.EntityFrameworkCore;
using Novaula.models;

namespace Novaula.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options) {}

        public DbSet<pivete> pivetes {get; set;}
    }
}