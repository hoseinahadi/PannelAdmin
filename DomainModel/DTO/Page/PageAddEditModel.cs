using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Page
{
    public class PageAddEditModel
    {
        public int PageId { get; set; }
        [Required(ErrorMessage = " نام صفحه را وارد کنید ")]
        [Display(Name = " نام صفحه ")]
        public string PageName { get; set; }

    }
}
