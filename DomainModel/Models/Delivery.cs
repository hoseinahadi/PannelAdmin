using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int CarrierId { get; set; }
        public int CurrencyId { get; set; }

        public string DeliveryName { get; set; }
        public decimal Price { get; set; }
        public Carrier Carrier { get; set; }
        public Currency Currency { get; set; }
        
        

    }
}
