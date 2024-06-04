using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Category
{
    public class CategoryAddOrEditModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = " نام دسته بندی را وارد کنید ")]
        [Display(Name = " نام دسته بندی ")]
        public string CategoryName { get; set; }
        [Display(Name = " توضیحات دسته بندی ")]
        public string CategoryDescription { get; set; }
        public int? ParentId { get; set; }
        public string Lineage { get; set; }
        public int ProductCount { get; set; }
        public int Depth { get; set; }

    }
}
