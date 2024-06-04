using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ProductDiscount
    {
        public int ProductDiscountId { get; set; }
        public int DiscountId { get; set; }
        public int ProductId { get; set; }
        public Discount Discount { get; set; }
        public Product Product { get; set; }


    }
}
