using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderApplicationAPi.Domain;
using OrderApplicationAPi.Data.Configurations;
using Microsoft.Extensions.Logging;

namespace OrderApplicationAPi.Data
{
    public class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Data source =(localdb)\\mssqllocaldb; Initial Catalog=OrderDB; Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            MapForgottenProps(modelBuilder);
        }

        private void MapForgottenProps(ModelBuilder modelBuilder)
        {
            foreach(var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string);
                foreach(var property in properties)
                {
                    if(string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue) 
                    {
                        /*property.SetMaxLength(100);*/
                        property.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }
    }
}
