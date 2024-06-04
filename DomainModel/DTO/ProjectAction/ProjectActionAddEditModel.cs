using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.ProjectAction
{
    public class ProjectActionAddEditModel
    {
        public int ProjectActionId { get; set; }

        [Required(ErrorMessage = "نام اکشن را وارد  کنید")]
        [Display(Name = "نام اکشن ")]
        public string ProjectActionName { get; set; }


        [Required(ErrorMessage = "عنوان فارسی اکشن را وارد  کنید")]
        [Display(Name = "عنوان فارسی اکشن ")]
        public string PersianTitle { get; set; }
    }
}
