using Microsoft.EntityFrameworkCore;
using AquaSenseAPI.Models;

namespace AquaSenseAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sensor> Sensores { get; set; }

        public DbSet<Consumo> Consumos { get; set; }

        public DbSet<Vazamento> Vazamentos { get; set; }
    }
}