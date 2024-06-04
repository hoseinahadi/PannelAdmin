using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OrderDiscount
    {
        public int OrderDiscountId { get; set; }
        public int DiscountId { get; set; }
        public int OrderId { get; set; }
        public Discount Discount { get; set; }
        public Order Order { get; set; }

    }
}
