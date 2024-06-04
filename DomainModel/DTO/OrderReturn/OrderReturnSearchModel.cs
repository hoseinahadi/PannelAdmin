using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.OrderReturn
{
    public class OrderReturnSearchModel : PageModel
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public int AddressId { get; set; }
        public int CurrencyId { get; set; }
        public string State { get; set; }
        public string Question { get; set; }
        public DateTime AddDate { get; set; }
    }
}
