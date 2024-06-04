using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public float Percent { get; set; }
        public List<CategoryDiscount> CategoryDiscounts { get; set; }
        public List<UserDiscount> UserDiscounts { get; set; }
        public List<EmployeeDiscount> EmployeeDiscounts { get; set; }
        public List<CountryDiscount> CountryDiscounts { get; set; }
        public List<OrderDiscount> OrderDiscounts { get; set; }
        public List<ProductDiscount> ProductDiscounts { get; set; }

        public Discount()
        {
            this.CategoryDiscounts = new List<CategoryDiscount>();
            this.UserDiscounts = new List<UserDiscount>();
            this.EmployeeDiscounts = new List<EmployeeDiscount>();
            this.CountryDiscounts = new List<CountryDiscount>();
            this.OrderDiscounts = new List<OrderDiscount>();
            this.ProductDiscounts = new List<ProductDiscount>();
        }
    }
}
