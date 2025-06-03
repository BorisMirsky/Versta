using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Versta.Core.Models;

namespace Versta.DataAccess
{
    public class VerstaDbContext : DbContext
    {
        // postgres ругался на формат datetime
        static VerstaDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }


        public VerstaDbContext(DbContextOptions<VerstaDbContext> options)
                : base(options)
        {}

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.OrderConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.UserConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.RoleConfiguration()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
