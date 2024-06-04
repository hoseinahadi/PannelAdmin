using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Connection
    {
        public int ConnectionId { get; set; }
        public int PageId { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Page Page { get; set; }
        public List<GuestUser> GuestUsers { get; set; }

        public Connection()
        {
            this.GuestUsers= new List<GuestUser>();
        }


    }
}
