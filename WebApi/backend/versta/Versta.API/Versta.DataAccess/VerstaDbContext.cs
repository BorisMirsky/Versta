using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Versta.Core.Models;

namespace Versta.DataAccess
{
    public class VerstaDbContext : DbContext
    {
        public VerstaDbContext(DbContextOptions<VerstaDbContext> options)
                : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(Role).Assembly);
            modelBuilder.Entity<Order>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Order>()
                .Property(o => o.AdressTo);
            modelBuilder.Entity<Order>()
                .Property(o => o.CityTo);
            modelBuilder.Entity<Order>()
                .Property(o => o.CityFrom);
            modelBuilder.Entity<Order>()
                .Property(o => o.AdressFrom);
            modelBuilder.Entity<Order>()
                .Property(o => o.Weight);
            modelBuilder.Entity<Order>()
                .Property(o => o.Date);
            modelBuilder.Entity<Order>()
                .Property(o => o.SpecialNote);
            //
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.UserName);
            modelBuilder.Entity<User>()
                .Property(u => u.Email);
            modelBuilder.Entity<User>()
                .Property(u => u.IsActive);
            modelBuilder.Entity<User>()
                .Property(u => u.Role);
            modelBuilder.Entity<User>()
                .Property(u => u.Password);
            modelBuilder.Entity<User>()
                .Property(u => u.Token);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
