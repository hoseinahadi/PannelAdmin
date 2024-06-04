using AdminPannel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BusinessServices.Services;
using DomainModel.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AdminPannel.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthHelper _authHelper;
        private readonly IAccessBusiness _accessBusiness;
        private readonly IMessageBusiness _messageBusiness;
        private readonly IUserMessageBusiness _userMessageBusiness;
        private readonly IUserBusiness _userBusiness;
        private readonly IAccountApplication _application;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IAuthHelper authHelper, IAccessBusiness accessBusiness, IMessageBusiness messageBusiness, IUserMessageBusiness userMessageBusiness, IUserBusiness userBusiness, IAccountApplication application, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _authHelper = authHelper;
            _accessBusiness = accessBusiness;
            _messageBusiness = messageBusiness;
            _userMessageBusiness = userMessageBusiness;
            _userBusiness = userBusiness;
            _application = application;
            _httpContextAccessor = httpContextAccessor;
        }


        public  IActionResult HomePage()
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies["UserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            var messages = _messageBusiness.GetAll();
            var count = 0;
            foreach (var item in messages)
            {
                if (item.Read==false)
                {
                    count++;
                }
            }
            ViewBag.FullName = _httpContextAccessor.HttpContext.Request.Cookies["FullName"];
            ViewBag.UserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            ViewBag.RoleId = _httpContextAccessor.HttpContext.Request.Cookies["RoleId"];
            ViewBag.message = messages;
            ViewBag.messageNotReadCount = count;
            ViewBag.usermessage = _userMessageBusiness.GetAll();
            ViewBag.usermessage = _userMessageBusiness.GetAll();
            return View();
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
