using BusinessServices.Services;
using DomainModel.DTO.Message;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    [ViewComponent(Name = "MessageNotRead")]
    public class MessageNotReadViewComponents:ViewComponent
    {
        public IViewComponentResult Invoke(List<MessageNotRead> model)
        {
            return View(model);
        }
    }
}
