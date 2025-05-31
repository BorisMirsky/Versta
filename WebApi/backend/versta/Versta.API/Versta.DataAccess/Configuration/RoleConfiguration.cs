using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Versta.Core.Models;
//using Versta.DataAccess.Entities;



namespace Versta.DataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>  //IdentityRole
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            //builder
            //    .HasMany(r => r.Users)
            //    .WithOne(u => u.Rolename);
            builder
                .Property(r => r.Name)
                .IsRequired();
            builder.HasData(
                    new Role("Admin")
                    {
                        Name = "ADMIN"
                    },
                    new Role("Manager")
                    {
                        Name = "MANAGER"
                    },
                    new Role("Visitor")
                    {
                        Name = "VISITOR"
                    }
            );
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
    }
}