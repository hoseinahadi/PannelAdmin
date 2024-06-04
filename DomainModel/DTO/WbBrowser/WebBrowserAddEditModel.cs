using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.WbBrowser
{
    public class WebBrowserAddEditModel
    {
        public int WebBrowserId { get; set; }
        [Required(ErrorMessage = " نام مرورگر را وارد کنید ")]
        [Display(Name = " نام مرورگر ")]
        public string WebBrowserName { get; set; }


    }
}
