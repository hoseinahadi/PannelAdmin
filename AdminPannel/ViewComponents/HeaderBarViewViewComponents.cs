using BusinessServices.Services;
using DomainModel.DTO.Message;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    [ViewComponent(Name = "HeaderBar")]
    public class HeaderBarViewViewComponents : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HeaderBarViewViewComponents(IHttpContextAccessor httpContextAccessor)
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
