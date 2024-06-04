using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Supplier
{
    public class SupplierSearchResult
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Note { get; set; }
        public string PhoneNumber { get; set; }

    }
}
