using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.ProjectController
{
    public class ProjectControllerAddEditModel
    {
        public int ProjectControllerId { get; set; }


        [Required(ErrorMessage = "نام کنتلر را وارد  کنید")]
        [Display(Name = "نام کنتلر ")]
        public string ProjectControllerName { get; set; }


        [Required(ErrorMessage = "عنوان فارسی کنتلر را وارد  کنید")]
        [Display(Name = "عنوان فارسی کنتلر ")]
        public string PersianTitle { get; set; }
    }
}
