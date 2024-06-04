using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ProductCart
    {
        public int ProductCartId { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
