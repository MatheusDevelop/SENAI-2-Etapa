using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Domains
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public string status { get; set; }
        public DateTime OrderDate { get; set; }
        public Pedido()
        {
            Id = Guid.NewGuid();
        }
    }
}
