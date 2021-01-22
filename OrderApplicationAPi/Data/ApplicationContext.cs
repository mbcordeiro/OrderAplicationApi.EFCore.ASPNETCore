using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderApplicationAPi.Domain;

namespace OrderApplicationAPi.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Data Source = .\SQLEXPRESS; Initial Catalog = OrderApplicationAPi; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(c =>
            {
                c.ToTable("Clients");
                c.HasKey(c => c.Id);
                c.Property(c => c.Name).HasColumnType("VARCHAR(80)").IsRequired();
                c.Property(c => c.Phone).HasColumnType("CHAR(11)");
                c.Property(c => c.Cep).HasColumnType("CHAR(8)").IsRequired();
                c.Property(c => c.City).HasColumnType("CHAR(2)").IsRequired();
                c.Property(c => c.State).HasMaxLength(60).IsRequired();

                c.HasIndex(i => i.Phone).HasName("idx_cliente_phone");
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Products");
                p.HasKey(p => p.Id);
                p.Property(p => p.BarCode).HasColumnType("VARCHAR(14)").IsRequired();
                p.Property(p => p.Description).HasColumnType("VARCHAR(60)");
                p.Property(p => p.Value).IsRequired();
                p.Property(p => p.ProductType).HasConversion<string>();
            });

            modelBuilder.Entity<Order>(o =>
            {
                o.ToTable("Orders");
                o.HasKey(o => o.Id);
                o.Property(o => o.OrderStart).HasDefaultValue("GETDATE()").ValueGeneratedOnAdd();
                o.Property(o => o.OrderStatus).HasConversion<string>();
                o.Property(o => o.TypeFreigth).HasConversion<int>();
                o.Property(o => o.Observation).HasColumnType("VARCHAR(512");
                o.HasMany(o => o.OrderItems).WithOne(o => o.Order).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(o =>
            {
                o.ToTable("OrderItems");
                o.HasKey(o => o.Id);
                o.Property(o => o.Quantity).HasDefaultValue(1).IsRequired();
                o.Property(o => o.Value).IsRequired();
                o.Property(o => o.Discount).IsRequired();
            });
        }
    }
}
