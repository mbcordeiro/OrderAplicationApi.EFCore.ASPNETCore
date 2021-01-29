using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderApplicationAPi.Domain;
using OrderApplicationAPi.ValueObjects;

namespace OrderApplicationAPi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*using var db = new Data.ApplicationContext();
            var existMigrate = db.Database.GetPendingMigrations().Any();
            if(existMigrate)
            {
                //
            }
            CreateHostBuilder(args).Build().Run();*/
            InsertData();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void InsertData()
        {
            var product = new Product
            {
                Description = "Product",
                BarCode = "1234567891234",
                Value = 10,
                ProductType = ProductType.Resale,
                Active = true
            };

            using var db = new Data.ApplicationContext();
            /*db.Products.Add(product);*/
            /*db.Set<Product>().Add(product);*/
            /*db.Entry(product).State = EntityState.Added;*/
            db.Add(product);

            var changes = db.SaveChanges();
            Console.WriteLine($"Affected data: {changes}");
        }
    }
}
