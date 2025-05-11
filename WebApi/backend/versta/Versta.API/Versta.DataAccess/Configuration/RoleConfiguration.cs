using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Versta.Core.Models;
using Versta.DataAccess.Entities;



namespace Versta.DataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
            new IdentityRole("Admin")
            {
                NormalizedName = "ADMIN"
            },
            new IdentityRole("Manager")
            {
                NormalizedName = "MANAGER"
            },
            new IdentityRole("Visitor")
            {
                NormalizedName = "VISITOR"
            }
            );
        }
    }
}