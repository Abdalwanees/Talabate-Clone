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
    internal class DelivaryMethodConfig : IEntityTypeConfiguration<DelivaryMethod>
    {
        public void Configure(EntityTypeBuilder<DelivaryMethod> builder)
        {
            builder.Property(o => o.Cost).HasColumnType("decimal(18,2)");
        }
    }
}
