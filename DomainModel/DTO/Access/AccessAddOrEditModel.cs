using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Access
{
    public class AccessAddOrEditModel
    {
        public int AccessId { get; set; }
        [Required(ErrorMessage = "  سطح دسترسی را وارد کنید ")]
        [Display(Name = " سطح دسترسی ")]
        public string AccessLevel { get; set; }
        public List<Models.Employee> Employees { get; set; }
    }
}
