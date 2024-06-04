using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ProductOrderReturn
    {
        public int ProductOrderReturnId { get; set; }
        public int ProductId { get; set; }
        public int OrderReturnId { get; set; }
        public Product Product { get; set; }
        public OrderReturn OrderReturn { get; set; }
    }
}
