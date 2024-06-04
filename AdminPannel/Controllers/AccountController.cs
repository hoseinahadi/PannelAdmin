using BusinessServices.Services;
using DomainModel.DTO.User;
using DomainModel.Models;
using Framework.Password;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IAccountApplication _accountApplication;
        private readonly IUserBusiness _userBusiness;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthHelper _authHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IAccountApplication accountApplication, IUserBusiness userBusiness, IPasswordHasher passwordHasher, IAuthHelper authHelper, IHttpContextAccessor httpContextAccessor)
        {
            _accountApplication = accountApplication;
            _userBusiness = userBusiness;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
            _httpContextAccessor = httpContextAccessor;

        }

        public IActionResult Index()
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies["UserId"]!=null)
            {
                ViewBag.FullName = _httpContextAccessor.HttpContext.Request.Cookies["FullName"];
                return RedirectToAction("HomePage", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            _accountApplication.LogoutUser();
            return RedirectToAction("Index","Account");
        }
        [HttpGet]
        public IActionResult SignInPage()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(UserAddEditModel model)
        {
            if (model.FirstName == null)
            {
                return Json(new { status = "error", message = " نام را وارد کنید " });
            }
            if (model.LastName == null)
            {
                return Json(new { status = "error", message = " نام خانوادگی را وارد کنید " });
            }
            if (model.UserName == null)
            {
                return Json(new { status = "error", message = " نام کاربری را وارد کنید " });
            }
            if (model.Password==null)
            {
                return Json(new { status = "error", message = " رمز عبور را وارد کنید " });
            }
            if (model.Email == null)
            {
                return Json(new { status = "error", message = " ایمیل را وارد کنید " });
            }

            model.Password = _passwordHasher.Hash(model.Password);
            if (model.RoleId==null || model.RoleId == 0)
            {
                model.RoleId = 3;
            }
            if (model.GenderId == null || model.GenderId == 0)
            {
                model.GenderId = 1;
            }
            model.AddDate= DateTime.Now;
            var result = _userBusiness.Add(model);
            return Json(result);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(UserAddEditModel model)
        {
            if (model.UserNameLogIn == null)
            {
                return Json(new { status = "error", message = " نام کاربری را وارد کنید " });
            }
            if (model.PasswordLogIn == null)
            {
                return Json(new { status = "error", message = " رمز عبور را وارد کنید " });
            }
            

            model.Password = _passwordHasher.Hash(model.PasswordLogIn);
            var login = new Login
            {
                Password = model.PasswordLogIn,
                Username = model.UserNameLogIn,
            };
            var result = _accountApplication.Login(login);
            
            if (result.Success == true)
            {
                
                return RedirectToAction("HomePage", "Home");
            }

            return Json(result);

        }
    }
}
