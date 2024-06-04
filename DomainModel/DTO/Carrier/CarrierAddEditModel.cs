using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Carrier
{
    public class CarrierAddEditModel
    {
        public int CarrierId { get; set; }
        public int LocationId { get; set; }
        [Required(ErrorMessage = " نام حمل کننده را وارد کنید ")]
        [StringLength(50)]
        [Display(Name = " نام حامل ")]
        public string CarrierName { get; set; }
        [Required(ErrorMessage = " شماره حمل کننده را وارد کنید ")]
        [Display(Name = " شماره حامل ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = " وضعیت حمل کننده را وارد کنید ")]
        [Display(Name = " وضعیت حامل ")]
        public string Active { get; set; }
        [Required(ErrorMessage = " ادرس اینترنتی حمل کننده را وارد کنید ")]
        [Display(Name = " ادرس اینترنتی حامل ")]
        public string Url { get; set; }
        
    }
}
