using BusinessServices.Services;
using DomainModel.DTO.Message;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    
    [ViewComponent(Name = "BaseView")]
    public class BaseViewViewComponents : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseViewViewComponents(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.FullName = _httpContextAccessor.HttpContext.Request.Cookies["FullName"];
            return View();
        }
    }
}
