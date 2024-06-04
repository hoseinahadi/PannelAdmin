using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Page
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public List<Connection> Connections { get; set; }

        public Page()
        {
            this.Connections = new List<Connection>();
        }
    }
}
