using DataAccessServices.Services.Base;
using DomainModel.Assist;
using DomainModel.DTO.Conversation;
using DomainModel.DTO.OrderProduct;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IConversationMessageRepository : IBaseRepository<ConversationMessage,int>
    {
        List<ConversationMessage> GetConversationWithMessageId(int messageid);
    }
}
