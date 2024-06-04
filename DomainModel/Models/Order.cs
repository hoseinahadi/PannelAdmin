using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }
        
        public int CurrencyId { get; set; }

        
        public int? EmployeeId { get; set; }
        public string Payment { get; set; }
        public string ShoppingPhone { get; set; }
        public string SecureKey { get; set; }
        public int ProductCount { get; set; }
        public DateTime AddDate { get; set; }

        public Address Address { get; set; }
        public Employee Employee { get; set; }
        public User User { get; set; }
        public Currency Currency { get; set; }
        
        public List<OrderMessage> OrderMessages { get; set; }
        public List<OrderReturn> OrderReturns { get; set; }
        public List<OrderDiscount> OrderDiscounts { get; set; }
        public List<OrderTax> OrderTaxes { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }

        public Order()
        {
            this.OrderMessages = new List<OrderMessage>();
            this.OrderReturns = new List<OrderReturn>();
            this.OrderDiscounts = new List<OrderDiscount>();
            this.OrderTaxes =   new List<OrderTax>();
            this.OrderProducts =   new List<OrderProduct>();
        }


    }
}
