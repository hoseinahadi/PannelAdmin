using DataAccessServices.Services.Base;
using DomainModel.DTO.OrderReturnMessage;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IOrderReturnMessageRepository : IBaseRepositorySearchable<OrderReturnMessage,int, OrderReturnMessage, OrderReturnMessageComplexResult>
    {
        
    }
}
