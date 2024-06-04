using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DomainModel.DTO.Carrier
{
    public class CarrierSearchResult
    {
        public int CarrierId { get; set; }
        public int LocationId { get; set; }
        public string CarrierName { get; set; }
        public string Phone { get; set; }
        public string Active { get; set; }
        public string Url { get; set; }
        

    }
}
