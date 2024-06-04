using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Carrier
    {
        public int CarrierId { get; set; }
        public int LocationId { get; set; }
        public string CarrierName { get; set; }
        public string Phone { get; set; }
        public string Active { get; set; }
        public string Url { get; set; }
        public List<Delivery> Deliveries { get; set; }

        public Carrier()
        {
            this.Deliveries=new List<Delivery>();
        }
        
        
    }
}
