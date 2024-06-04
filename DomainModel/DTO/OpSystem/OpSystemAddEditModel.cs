using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.OpSystem
{
    public class OpSystemAddEditModel
    {
        public int OpSystemId { get; set; }
        [Required(ErrorMessage = " نام سیستم را وارد کنید " )]
        [Display(Name = " نام سیستم  ")]
        public string OpName { get; set; }
    }
}
