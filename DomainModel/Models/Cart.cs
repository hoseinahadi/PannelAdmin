using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public DateTime AddDate { get; set; }
        public int UserId { get; set; }
        public List<ProductCart> ProductCarts { get; set; }
        public User User { get; set; }

        public Cart()
        {
            this.ProductCarts= new List<ProductCart>();
        }
        
    }
}
