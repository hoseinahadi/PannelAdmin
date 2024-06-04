using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class CategoryDiscount
    {
        public int CategoryDiscountId { get; set; }
        public int CategoryId { get; set; }
        public int DiscountId { get; set; }
        public Category Category { get; set; }
        public Discount Discount { get; set; }
    }
}
