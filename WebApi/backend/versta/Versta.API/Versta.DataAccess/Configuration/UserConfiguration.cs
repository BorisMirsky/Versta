using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta.Core.Models;
//using Versta.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;



namespace Versta.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            //builder.HasData(new User[]);
            //builder
            //    .HasOne(u => u.Rolename)
            //    .WithMany(r => r.)
            //    .HasForeignKey(u => u.RoleId);
            builder.Property(u => u.UserName)
                .IsRequired();
            builder.Property(u => u.Email)
                .IsRequired();
            builder.Property(u => u.IsActive)
                .IsRequired();
            builder.Property(u => u.Rolename)
                .IsRequired();
            builder.Property(u => u.RoleId)
                .IsRequired();
            builder.Property(u => u.Password)
                .IsRequired();
            builder.Property(u => u.Token)
                .IsRequired();
        }
    }
}
