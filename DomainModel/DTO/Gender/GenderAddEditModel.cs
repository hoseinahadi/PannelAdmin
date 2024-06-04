using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Gender
{
    public class GenderAddEditModel
    {
        public int GenderId { get; set; }
        [Required(ErrorMessage = " نام جنسیت را وارد کنید ")]
        [Display(Name = " نام جنسیت ")]
        public string GenderName { get; set; }

    }
}
