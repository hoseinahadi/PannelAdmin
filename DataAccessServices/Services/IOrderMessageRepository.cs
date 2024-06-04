using DataAccessServices.Services.Base;
using DomainModel.DTO.OrderMessage;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IOrderMessageRepository : IBaseRepositorySearchable<OrderMessage,int,OrderMessage,OrderMessageComplexResult>
    {
        
    }
}
