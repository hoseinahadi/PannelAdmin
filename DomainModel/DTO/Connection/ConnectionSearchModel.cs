using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Connection
{
    public class ConnectionSearchModel : PageModel
    {
        public int ConnectionId { get; set; }
        public int PageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
