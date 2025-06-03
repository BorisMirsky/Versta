using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Versta.Core.Models;
using Microsoft.EntityFrameworkCore;



namespace Versta.DataAccess.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>   
    {
        public void Configure(EntityTypeBuilder<Order> builder)  
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.SpecialNote)
                .HasMaxLength(Order.MAX_NOTE_LEN);
            builder.Property(o => o.AdressFrom)
                .IsRequired();
            builder.Property(o => o.CityFrom)
                .IsRequired();
            builder.Property(o => o.AdressTo)
                .IsRequired();
            builder.Property(o => o.CityTo)
                .IsRequired();
            builder.Property(o => o.Date)
                .IsRequired();
            builder.Property(o => o.Weight)
                .IsRequired();
        }
    }
}
