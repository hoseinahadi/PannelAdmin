using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Role
{
    public class RoleAddEditModel
    {
        public int RoleId { get; set; }



        [Required(ErrorMessage = "نام رول را وارد  کنید")]
        [Display(Name = "نام رول ")]
        public string RoleName { get; set; }
    }
}
