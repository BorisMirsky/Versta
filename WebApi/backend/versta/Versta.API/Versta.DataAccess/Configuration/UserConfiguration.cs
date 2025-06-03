using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Versta.Core.Models;
using Microsoft.EntityFrameworkCore;



namespace Versta.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
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
