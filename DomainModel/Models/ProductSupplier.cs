using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ProductSupplier
    {
        public int ProductSupplierId { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public Supplier Supplier { get; set; }
        public Product Product { get; set; }
    }
}
