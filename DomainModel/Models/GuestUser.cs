using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class GuestUser
    {
        public int GuestUserId { get; set; }
        public int WebBrowserId { get; set; }
        public int ConnectionId { get; set; }
        public bool JavaScript { get; set; }
        public int ScreenResolutionX { get; set; }
        public int ScreenResolutionY { get; set; }
        public string AcceptLanguage { get; set; }
        public bool AdobeFlash { get; set; }
        public List<GuestUserMessage> GuestUserMessages { get; set; }
        public OpSystem OpSystem { get; set; }
        public WebBrowser WebBrowser { get; set; }
        public Connection Connection { get; set; }

        public GuestUser()
        {
            this.GuestUserMessages= new List<GuestUserMessage>();
        }



    }
}
