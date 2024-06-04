using DataAccessServices.Services.Base;
using DomainModel.DTO.GuestUserMessage;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IGuestUserMessageRepository : IBaseRepositorySearchable<GuestUserMessage,int, GuestUserMessage, GuestUserMessageComplexResult>
    {
        
    }
}
