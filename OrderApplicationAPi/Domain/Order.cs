using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderApplicationAPi.ValueObjects;

namespace OrderApplicationAPi.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime OrderStart { get; set; }
        public DateTime OrderEnd { get; set; }
        public TypeFreight TypeFreigth { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Observation { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
