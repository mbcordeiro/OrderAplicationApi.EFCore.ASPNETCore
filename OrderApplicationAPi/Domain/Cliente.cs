using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApplicationAPi.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
