using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Employee
{
    public class EmployeeAddOrEditModel
    {
        public int EmployeeId { get; set; }
        public int AccessId { get; set; }
        [Required(ErrorMessage = " نام   کارمند را وارد کنید ")]
        [Display(Name = " نام کارمند  ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " نام  خانوادگی کارمند را وارد کنید ")]
        [Display(Name = " نام خانوادگی کارمند  ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = " ایمیل را وارد کنید ")]
        [Display(Name = " ایمیل  ")]
        public string Email { get; set; }
        [Required(ErrorMessage = " کلمه عبور را وارد کنید ")]
        [Display(Name = " کلمه عبور  ")]
        public string Password { get; set; }

        public bool Active { get; set; }

        public int? ParentId { get; set; }

        public int RoleId { get; set; }




    }
}
