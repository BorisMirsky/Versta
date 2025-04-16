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
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            // throw new NotImplementedException();
            builder.HasKey(x => x.Id);
            builder.Property(o => o.SpecialNote)
                  .HasMaxLength(Order.MAX_NOTE_LEN)
                  .IsRequired();
            builder.Property(o => o.AdressFrom)
                .IsRequired();
            builder.Property(o => o.CityFrom)
                .IsRequired();
            builder.Property(o => o.AdressTo)
                .IsRequired();
            builder.Property(o => o.CityTo)
                .IsRequired();
            builder.Property(o => o.SpecialNote)
                    .IsRequired();
            builder.Property(o => o.Date)
                .IsRequired();
            builder.Property(o => o.Weight)
                .IsRequired();
        }
    }
}
