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
            /*InsertData();*/
            /*InsertMuchDatas();*/
            /*QueryDatas();*/
            /*InsertOrder();*/
            /*QueryOderLoadScheduled();*/
            UpdateDatas();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void QueryDatas()
        {
            using var db = new Data.ApplicationContext();
            /*var query = (from c in db.Clients where c.Id > 0 select c);*/
            var queryLinq = db.Clients.AsNoTracking().Where(c => c.Id > 0).OrderBy(c => c.Id).ToList();
            foreach(var client in queryLinq)
            {
                Console.WriteLine($"Query client:{client.Id}");
                /*db.Clients.Find(client.Id);*/
                db.Clients.FirstOrDefault(c => c.Id == client.Id);
            }
        }

        private static void QueryOderLoadScheduled()
        {
            using var db = new Data.ApplicationContext();
            var order = db.Orders.Include(o => o.OrderItems).ThenInclude(o => o.Product).ToList();
            Console.WriteLine(order.Count);
        }
        private static void InsertMuchDatas()
        {
            var product = new Product
            {
                Description = "Product",
                BarCode = "1234567891234",
                Value = 10,
                ProductType = ProductType.Resale,
                Active = true
            };

            var client = new Client
            {
                Name = "Client",
                Phone = "47999999999",
                Cep = "12345678",
                City = "Blumenau",
                State = "SC",
            };

            var listClient = new[]
            {
                  new Client
                {
                    Name = "Client",
                    Phone = "47999999999",
                    Cep = "12345678",
                    City = "Blumenau",
                    State = "SC",
                },
                    new Client
                {
                    Name = "Client",
                    Phone = "47999999999",
                    Cep = "12345678",
                    City = "Blumenau",
                    State = "SC",
                },
            };

            using var db = new Data.ApplicationContext();
            /*db.AddRange(product, client);*/
            /*db.Set<Client>().AddRange(listClient);*/
            db.Clients.AddRange(listClient);
            var changes = db.SaveChanges();
            Console.WriteLine($"Affected data: {changes}");
        }

        private static void InsertDatas()
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

        public static void InsertOrder()
        {
            using var db = new Data.ApplicationContext();

            var client = db.Clients.FirstOrDefault();
            var product = db.Products.FirstOrDefault();

            var order = new Order
            {
                ClientId = client.Id,
                OrderStart = DateTime.Now,
                OrderEnd = DateTime.Now,
                Observation = "Order",
                OrderStatus = OrderStatus.Analise,
                TypeFreigth = TypeFreight.NoneFreight,
                OrderItems = new List<OrderItem>
                   {
                      new OrderItem
                      {
                         ProductId = product.Id,
                         Discount = 0,
                         Quantity = 1,
                         Value = 10
                      }
                    }
            };
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public static void UpdateDatas()
        {
            using var db = new Data.ApplicationContext();
            /*var client = db.Clients.Find(1);*/
            var client = new Client
            {
                Id = 1
            };

            client.Name = "Client up";
            var clientDesconnect = new
            {
                Nome = "Client Desconnect",
                Phone = "47999999999"
            };

            /*db.Entry(client).State = EntityState.Modified;*/
            /*db.Clients.Update(client);*/
            db.Attach(client);
            db.Entry(client).CurrentValues.SetValues(clientDesconnect);
            db.SaveChanges();
        }
    }
}
