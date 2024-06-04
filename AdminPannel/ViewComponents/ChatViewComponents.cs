using BusinessServices.Services;
using DomainModel.DTO.Conversation;
using DomainModel.DTO.Message;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    [ViewComponent(Name = "Chat")]
    public class ChatViewComponents : ViewComponent
    {
        private readonly IConversationBusiness _conversationBusiness;
        private readonly IMessageBusiness _messageBusiness;

        public ChatViewComponents(IConversationBusiness conversationBusiness, IMessageBusiness messageBusiness)
        {
            _conversationBusiness = conversationBusiness;
            _messageBusiness = messageBusiness;
        }
        public IViewComponentResult Invoke(int id)
        {
            List<Message> message = new List<Message>();
            var messageconv = _conversationBusiness.GetConversationMessage(id);
            foreach (var item in messageconv)
            {
                var result = _messageBusiness.Get(item.MessageId);
                message.Add(result);
            }
            return View(message);
        }
    }
}
