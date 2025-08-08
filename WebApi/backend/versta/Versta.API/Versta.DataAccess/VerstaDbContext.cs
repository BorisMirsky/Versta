using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Versta.Core.Models;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



namespace Versta.DataAccess
{
    using BCrypt.Net;
    public class VerstaDbContext : DbContext
    {
        public VerstaDbContext(DbContextOptions<VerstaDbContext> options) : base(options)
        {
            // postgres ругался на формат datetime
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }


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
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User {  Id = Guid.NewGuid(),
                            Email = "admin@gmail.com",
                            Password = BCrypt.HashPassword("adminpassword"),
                            UserName = "Admin",
                            Rolename = "admin"
                          },
                new User {  Id = Guid.NewGuid(),
                            Email = "manager@gmail.com",
                            Password = BCrypt.HashPassword("managerpassword"),
                            UserName = "manager Petrov",
                            Rolename = "manager"
                          },
                new User {  Id = Guid.NewGuid(),
                            Email = "visitor@gmail.com",
                            Password = BCrypt.HashPassword("visitorpassword"),
                            UserName = "Visitor Ivanov",
                            Rolename = "visitor"
                          }
                });
        }
    }
}
