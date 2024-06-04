using DomainModel.Assist;
using DomainModel.DTO.Conversation;
using DomainModel.DTO.OrderProduct;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IConversationBusiness
    {
        OperationResult Add(ConversationAddEditModel model);
        OperationResult Update(ConversationAddEditModel model);
        OperationResult Delete(int id);
        Conversation Get(int id);
        List<Conversation> GetAll();
        List<ConversationMessage> GetConversationMessage(int id);
        List<UserConversation> GetUserConversation(int id);
        List<ConversationMessage> GetConversationWithMessageId(int messageid);
    }
}
