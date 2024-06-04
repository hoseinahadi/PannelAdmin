using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Currency
{
    public class CurrencyAddOrEditModel
    {
        public int CurrencyId { get; set; }
        [Required(ErrorMessage = " نام ارز را وارد کنید  ")]
        [Display(Name = " نام ارز  ")]
        public string CurrencyName { get; set; }
        [Display(Name = " نرخ تبدیل نسبت به دلار   ")]
        public int ConversionRate { get; set; }
    }
}
