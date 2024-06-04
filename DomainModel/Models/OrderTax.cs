using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OrderTax
    {
        public int OrderTaxId { get; set; }
        public int TaxId { get; set;}
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Tax Tax { get; set; }


    }
}
