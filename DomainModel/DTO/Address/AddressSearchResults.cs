using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Address
{
    public class AddressSearchResults
    {
        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public int? CountryId { get; set; }
        public int? EmployeeId { get; set; }
        public int? SupplierId { get; set; }
        [Required(ErrorMessage = " وضعیت آدرس را وارد کنید ")]
        [Display(Name = " وضعیت ")]
        public bool State { get; set; }
        [Required(ErrorMessage = " شهر را وارد کنید ")]
        [Display(Name = " شهر ")]
        public string City { get; set; }
        [Required(ErrorMessage = " کشور  را وارد کنید ")]
        [Display(Name = " کشور ")]
        public string Country { get; set; }
        [Required(ErrorMessage = " خیابان را وارد کنید ")]
        [Display(Name = " خیابان ")]
        public string Street { get; set; }
        [Required(ErrorMessage = " پلاک را وارد کنید ")]
        [Display(Name = " پلاک ")]
        public string plaq { get; set; }
        [Required(ErrorMessage = " کد پستی را وارد کنید ")]
        [Display(Name = " کد پستی ")]
        public string PostCode { get; set; }
        [Display(Name = " نام شرکت ")]
        public string CompanyName { get; set; }
        
        [Display(Name = " یاد داشت ")]
        public string Note { get; set; }
        [Required(ErrorMessage = " شماره ثابت را وارد کنید ")]
        [Display(Name = " شماره ثابت ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = " شماره همراه را وارد کنید ")]
        [Display(Name = " شماره همراه ")]
        public string MobileNumber { get; set; }
    }
}
