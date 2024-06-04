using DataAccessServices.Services.Base;
using DataAccessServices.Services.Base;
using DomainModel.DTO.OrderProduct;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IOrderProductRepository : IBaseRepositorySearchable<OrderProduct,int,OrderProduct,OrderProductComplexResult>
    {
        
    }
}
