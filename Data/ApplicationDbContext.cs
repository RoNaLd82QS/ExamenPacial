using Microsoft.EntityFrameworkCore;
using EquiposPeruanos.Models;

namespace EquiposPeruanos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        
    }
}



