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
        public Cliente Client { get; set; }
        public DateTime OrderStart { get; set; }
        public DateTime OrderEnd { get; set; }
        public TypeFreight typeFreigth { get; set; }
        public OrderStatus orderStatus { get; set; }
        public string Observation { get; set; }
        public ICollection<OrderItem> orderItems { get; set; }
    }
}
