using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class WebBrowser
    {
        public int WebBrowserId { get; set; }
        public string WebBrowserName { get; set; }
        public List<GuestUser> GuestUsers { get; set; }

        public WebBrowser()
        {
            this.GuestUsers = new List<GuestUser>();
        }

    }
}
