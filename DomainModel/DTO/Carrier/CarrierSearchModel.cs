using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Carrier
{
    public class CarrierSearchModel : PageModel
    {
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public string Phone { get; set; }
        public string Active { get; set; }
    }
}
