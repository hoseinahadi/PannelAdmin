using DataAccessServices.Services.Base;
using DomainModel.DTO.UserMessage;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IUserConversationRepository : IBaseRepository<UserConversation,int>
    {
        
    }
}
