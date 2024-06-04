using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Delivery
{
    public class DeliverySearchResult
    {
        public int DeliveryId { get; set; }
        public int CarrierId { get; set; }
        public int CurrencyId { get; set; }
        public string DeliveryName { get; set; }
        public decimal Price { get; set; }
    }
}
