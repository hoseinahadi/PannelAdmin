using DataAccessServices.Services.Base;
using DomainModel.DTO.Conversation;
using DomainModel.DTO.OrderProduct;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IConversationRepository : IBaseRepository<Conversation,int>
    {
        List<UserConversation> GetUserConversation(int id);
        List<ConversationMessage> GetUserConversationMessage(int id);
    }
}
