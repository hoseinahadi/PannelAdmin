using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Supplier
{
    public class SupplierAddEditModel
    {
        public int SupplierId { get; set; }
        [Required(ErrorMessage = " نام تامین کننده را وارد کنید ")]
        [Display(Name = " نام تامین کننده ")]
        public string SupplierName { get; set; }

        [Display(Name = " یادداشت ")]
        public string Note { get; set; }
        [Required(ErrorMessage = " شماره تامین کننده را وارد کنید ")]
        [Display(Name = " شماره تامین کننده ")]
        public string PhoneNumber { get; set; }

        
    }
}
