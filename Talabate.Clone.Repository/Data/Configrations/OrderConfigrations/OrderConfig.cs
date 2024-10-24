using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabate.Clone.Core.Entites.Order.Aggregrate;

namespace Talabate.Clone.Repository.Data.Configrations.OrderConfigrations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(P => P.Status)
                   .HasConversion(
                orderStatus => orderStatus.ToString(),
                orderStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus),orderStatus)
                );
            // 1 - 1 total
            builder.OwnsOne(o => o.ShippingAddress, shippingAddress => shippingAddress.WithOwner());

            //builder.HasOne(o => o.Delivarymethod)
            //       .WithOne();
            //builder.HasIndex(O => O.DelivarymethodId).IsUnique();
            builder.Property(o => o.SubTotal)
                   .HasColumnType("decimal(18,2)");
            builder.HasOne(o => o.Delivarymethod).WithMany().OnDelete(DeleteBehavior.SetNull);
        }
    }
}
