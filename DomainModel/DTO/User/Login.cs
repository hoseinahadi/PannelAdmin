using System.ComponentModel.DataAnnotations;

namespace DomainModel.DTO.User
{
    public class Login
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage ="*")]
        public string Username { get; set; }

        [MinLength(6, ErrorMessage = "طول کلمه عبور حداقل ۶ کاراکتر است")]
        [Display(Name = "کلمه رمز")]
        [Required(ErrorMessage="*")]
        public string Password { get; set; }

        public string RedirectUrl { get; set; }
    }
}
