using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OrderHistory
    {
        public int OrderHistoryId { get; set; }
        
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
