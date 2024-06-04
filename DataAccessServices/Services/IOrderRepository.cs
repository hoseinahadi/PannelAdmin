using DataAccessServices.Services.Base;
using DomainModel.DTO.Order;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IOrderRepository:IBaseRepositorySearchable<Order,int,OrderSearchModel,OrderComplexResults>
    {
    }
}
