using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class SupplierImage
    {
        public int SupplierImageId { get; set; }
        public int ImageId { get; set; }
        public int SupplierId { get; set; }
        public Image Image { get; set; }
        public Supplier Supplier { get; set; }

    }
}
