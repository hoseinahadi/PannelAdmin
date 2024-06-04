using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Country
{
    public class CountryAddOeEditModel
    {
        public int CountryId { get; set; }
        [Required(ErrorMessage = " نام کشور را وارد کنید ")]
        [Display(Name = " نام کشور ")]
        public string CountryName { get; set; }
        [Display(Name = " کد کشور ")]
        public string CountryCode { get; set; }
        
        
    }
}
