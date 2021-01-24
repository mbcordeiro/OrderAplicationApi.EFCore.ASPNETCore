using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderApplicationAPi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApplicationAPi.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(c => c.Phone).HasColumnType("CHAR(11)");
            builder.Property(c => c.Cep).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(c => c.City).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(c => c.State).HasMaxLength(60).IsRequired();

            builder.HasIndex(i => i.Phone).HasName("idx_cliente_phone");
        }
    }
}
