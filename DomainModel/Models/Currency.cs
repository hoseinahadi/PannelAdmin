using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int ConversionRate { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderReturn> OrderReturns { get; set; }
        public List<Delivery> Deliveries { get; set; }

        public Currency()
        {
            this.Products= new List<Product>();
            this.Orders= new List<Order>();
            this.OrderReturns = new List<OrderReturn>();
            this.Deliveries= new List<Delivery>();
        }
    }
}
