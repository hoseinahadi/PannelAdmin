using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.GuestUser
{
    public class GuestUserSearchModel : PageModel
    {
        public bool JavaScript { get; set; }
        public int ScreenResolutionX { get; set; }
        public int ScreenResolutionY { get; set; }
        public string AcceptLanguage { get; set; }
        public bool AdobeFlash { get; set; }
    }
}
