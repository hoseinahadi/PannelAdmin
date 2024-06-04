using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Order
{
    public class OrderSearchModel : PageModel
    {
        public int AddressId { get; set; }
        public string UserName { get; set; }
        public string CurrencyName { get; set; }
        public string EmployeeName { get; set; }
        public string ShoppingPhone { get; set; }
        public string SecureKey { get; set; }
        public DateTime StartSearchDate { get; set; }
        public DateTime EndSearchDate { get; set; }
    }
}
