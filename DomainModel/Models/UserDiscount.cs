using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class UserDiscount
    {
        public int UserDiscountId { get; set; }
        public int DiscountId { get; set; }
        public int UserId { get; set; }
        public Discount Discount { get; set; }
        public User User { get; set; }
    }
}
