using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderApplicationAPi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApplicationAPi.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Quantity).HasDefaultValue(1).IsRequired();
            builder.Property(o => o.Value).IsRequired();
            builder.Property(o => o.Discount).IsRequired();
        }
    }
}
