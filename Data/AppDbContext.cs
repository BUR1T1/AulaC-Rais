using Microsoft.EntityFrameworkCore;
using NovaAula.models;

namespace Novaula.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options) {}

        public DbSet<Paciente> Pacientes {get; set;}
    }
}