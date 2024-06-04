using DataAccessServices.Services.Base;
using DomainModel.DTO.OrderDiscount;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IOrderDiscountRepository : IBaseRepositorySearchable<OrderDiscount,int,OrderDiscount,OrderDiscountComplexResult>
    {
        
    }
}
