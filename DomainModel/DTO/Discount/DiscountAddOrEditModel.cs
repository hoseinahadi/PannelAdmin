using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Discount
{
    public class DiscountAddOrEditModel
    {
        public int DiscountId { get; set; }
        [Required(ErrorMessage = " نام تخفیف را وارد کنید  ")]
        [Display(Name = " نام تخفیف ")]
        public string Name { get; set; }
        [Required(ErrorMessage = " درصد تخفیف را وارد کنید  ")]
        [Display(Name = " درصد تخفیف ")]
        public float Percent { get; set; }

    }
}
