using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta.Core.Models;
using Versta.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;



namespace Versta.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            // throw new NotImplementedException();
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName)
                  .IsRequired();
            builder.Property(u => u.Email)
                .IsRequired();
            builder.Property(u => u.IsActive)
                .IsRequired();
            builder.Property(u => u.Role)
                .IsRequired();
            builder.Property(u => u.Password)
                .IsRequired();
            builder.Property(u => u.Token)
                .IsRequired();
        }
    }
}
