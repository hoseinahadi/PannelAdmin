using DataAccessServices.Services.Base;
using DomainModel.DTO.UserMessage;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IUserMessageRepository : IBaseRepositorySearchable<UserMessage,int, UserMessage, UserMessageComplexResult>
    {
        
    }
}
