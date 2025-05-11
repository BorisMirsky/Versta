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
        {
        }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(logStream.WriteLine);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
