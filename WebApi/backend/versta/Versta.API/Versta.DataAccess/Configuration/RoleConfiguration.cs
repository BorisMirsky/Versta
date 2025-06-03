using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Versta.Core.Models;




namespace Versta.DataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>  //IdentityRole
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder
                .HasMany(r => r.Users)
                .WithOne(u => u.Role);
            builder
                .Property(r => r.Name)
                .IsRequired();
            builder.HasData(
                    new Role("Admin")
                    {
                        Id = 1,
                        Name = "ADMIN"
                    },
                    new Role("Manager")
                    {
                        Id = 2,
                        Name = "MANAGER"
                    },
                    new Role("Visitor")
                    {
                        Id = 3,
                        Name = "VISITOR"
                    }
            );
        }
    }
}


//builder.HasData(
//new IdentityRole("Admin")
//{
//    NormalizedName = "ADMIN"
//},
//new IdentityRole("Manager")
//{
//    NormalizedName = "MANAGER"
//},
//new IdentityRole("Visitor")
//{
//    NormalizedName = "VISITOR"
//}
//);
//}