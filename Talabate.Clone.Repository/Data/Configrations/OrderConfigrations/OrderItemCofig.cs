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
    internal class OrderItemCofig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(o => o.Product, product => product.WithOwner());
            builder.Property(o => o.Price)
                    .HasColumnType("decimal(18,2)");
        }
    }
}
