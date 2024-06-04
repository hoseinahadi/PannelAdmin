using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Tax
{
    public class TaxAddEditModel
    {
        public int TaxId { get; set; }
        [Required(ErrorMessage = " ارزش مالیات را وارد کنید ")]
        [Display(Name = " ارزش مالیات ")]
        public int TaxPercent { get; set; }
        [Required(ErrorMessage = " نام مالیات را وارد کنید ")]
        [Display(Name = " نام مالیات ")]
        public string TaxName { get; set; }
    }
}
