using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class EmployeeDiscount
    {
        public int EmployeeDiscountId { get; set; }
        public int EmployeeId { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
        public Employee Employee { get; set; }


    }
}
