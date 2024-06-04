using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Supplier
{
    public class SupplierSearchModel : PageModel
    {
        public string SupplierName { get; set; }
        public string Note { get; set; }
        public string PhoneNumber { get; set; }
    }
}
