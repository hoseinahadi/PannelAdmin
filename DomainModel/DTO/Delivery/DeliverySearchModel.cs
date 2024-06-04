using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Delivery
{
    public class DeliverySearchModel : PageModel
    {
        public int CarrierId { get; set; }
        public string DeliveryName { get; set; }
        public decimal Price { get; set; }
    }
}
