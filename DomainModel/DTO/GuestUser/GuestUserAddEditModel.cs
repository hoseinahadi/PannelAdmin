using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.GuestUser
{
    public class GuestUserAddEditModel
    {
        public int GuestUserId { get; set; }
        public int WebBrowserId { get; set; }
        public int ConnectionId { get; set; }
        public bool JavaScript { get; set; }
        public int ScreenResolutionX { get; set; }
        public int ScreenResolutionY { get; set; }
        public string AcceptLanguage { get; set; }
        public bool AdobeFlash { get; set; }

    }
}
