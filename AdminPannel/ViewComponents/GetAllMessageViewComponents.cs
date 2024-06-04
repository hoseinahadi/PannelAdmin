using BusinessServices.Services;
using DomainModel.DTO.Message;
using DomainModel.DTO.Order;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    [ViewComponent(Name = "GetAllMessage")]
    public class GetAllMessageViewComponents : ViewComponent
    {
        private readonly IMessageBusiness _messageBusiness;

        public GetAllMessageViewComponents(IMessageBusiness messageBusiness)
        {
            _messageBusiness = messageBusiness;
        }
        public IViewComponentResult Invoke()
        {
            var result = _messageBusiness.GetAll().OrderByDescending(x=>x.MessageId);
            return View(result);
        }
    }
}
