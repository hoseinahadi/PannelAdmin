using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OrderReturn
    {
        public int OrderReturnId { get; set; }
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public int AddressId { get; set; }
        public int CurrencyId { get; set; }
        public string State { get; set; }
        public string Question { get; set; }
        public DateTime AddDate { get; set; }
        public Address Address { get; set; }
        public Order Order { get; set; }
        public Currency Currency { get; set; }
        public Employee Employee { get; set; }
        public List<OrderReturnMessage> OrderReturnMessages { get; set; }
        public List<ProductOrderReturn> ProductOrderReturns { get; set; }

        public OrderReturn()
        {
            this.OrderReturnMessages = new List<OrderReturnMessage>();
            this.ProductOrderReturns = new List<ProductOrderReturn>();
        }


    }
}
