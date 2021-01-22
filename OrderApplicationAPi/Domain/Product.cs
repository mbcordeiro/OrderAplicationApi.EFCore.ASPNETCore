using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderApplicationAPi.ValueObjects;

namespace OrderApplicationAPi.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public ProductType productType { get; set; }
        public bool Active{ get; set; }
    }
}
