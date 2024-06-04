using DataAccessServices.Services.Base;
using DomainModel.DTO.OrderReturn;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IOrderReturnRepository:IBaseRepositorySearchable<OrderReturn,int,OrderReturnSearchModel,OrderReturnComplexResults>
    {
    }
}
