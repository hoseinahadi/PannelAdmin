using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Feature
{
    public class FeatureAddEditModel
    {
        public int FeatureId { get; set; }
        [Required(ErrorMessage = " نام ویژگی را وارد کنید ")]
        [Display(Name = " نام ویژگی ")]
        public string FeatureName { get; set; }
        [Required(ErrorMessage = " توضیحات ویژگی را وارد کنید ")]
        [Display(Name = " توضیحات ویژگی ")]
        public string FeatureDescription { get; set; }

        public int ProductId { get; set; }
    }
}
