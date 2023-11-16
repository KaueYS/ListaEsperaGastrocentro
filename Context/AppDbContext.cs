using ListaEsperaGastrocentro.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaEsperaGastrocentro.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Paciente> PACIENTES { get; set; }
    }
}
