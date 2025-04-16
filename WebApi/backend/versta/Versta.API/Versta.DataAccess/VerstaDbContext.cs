using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Versta.DataAccess
{
    public class VerstaDbContext : DbContext
    {
        //readonly StreamWriter logStream = new StreamWriter("mylog.txt", true);
        public VerstaDbContext(DbContextOptions<VerstaDbContext> options)
                : base(options)
        {
        }
        public DbSet<OrderEntity> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(logStream.WriteLine);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
