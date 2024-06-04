using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Tax
    {
        public int TaxId { get; set; }
        public int TaxPercent { get; set; }
        public string TaxName { get; set; }
        public List<OrderTax> OrderTaxes { get; set; }

        public Tax()
        {
            this.OrderTaxes = new List<OrderTax>();
        }
    }
}
