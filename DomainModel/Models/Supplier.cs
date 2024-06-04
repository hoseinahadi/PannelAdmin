using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Note { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }
        public List<SupplierImage> SupplierImages { get; set; }
        public List<Address> Addresses { get; set; }

        public Supplier()
        {
            this.ProductSuppliers=new List<ProductSupplier>();
            this.SupplierImages=new List<SupplierImage>();
            this.Addresses=new List<Address>();
        }
    }
}
