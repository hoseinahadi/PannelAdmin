using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class CountryDiscount
    {
        public int CountryDiscountId { get; set; }
        public int DiscountId { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public Discount Discount { get; set; }

    }
}
