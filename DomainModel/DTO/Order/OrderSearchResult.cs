using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Order
{
    public class OrderSearchResult
    {
        public int OrderId { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public int OrderHistoryId { get; set; }
        public int EmployeeId { get; set; }
        public string Payment { get; set; }
        public string ShoppingPhone { get; set; }
        public string SecureKey { get; set; }
        public int ProductCount { get; set; }
        public DateTime AddDate { get; set; }
    }
}
