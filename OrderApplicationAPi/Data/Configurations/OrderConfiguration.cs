using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderApplicationAPi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApplicationAPi.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderStart).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(o => o.OrderStatus).HasConversion<string>();
            builder.Property(o => o.TypeFreigth).HasConversion<int>();
            builder.Property(o => o.Observation).HasColumnType("VARCHAR(512)");
            builder.HasMany(o => o.OrderItems).WithOne(o => o.Order).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
