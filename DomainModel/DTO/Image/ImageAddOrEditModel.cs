using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace DomainModel.DTO.Image
{
    public class ImageAddOrEditModel
    {
        public int ImageId { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        public string ImageUrl { get; set; }
        [Required (ErrorMessage = " نام عکس را وارد کنید ")]
        [Display(Name = " نام عکس ")]
        public string ImageName { get; set; }
        public string ImageCode { get; set; }
        public IFormFile Picture { get; set; }


    }
}
