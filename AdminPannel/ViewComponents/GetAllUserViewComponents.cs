using Business.IMP;
using BusinessServices.Services;
using DomainModel.DTO.Message;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    [ViewComponent(Name = "GetAllUser")]
    public class GetAllUserViewComponents : ViewComponent
    {
        private readonly IUserBusiness _userBusiness;

        public GetAllUserViewComponents(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        public IViewComponentResult Invoke()
        {
            var result = _userBusiness.GetAll();
            return View(result);
        }
    }
}
