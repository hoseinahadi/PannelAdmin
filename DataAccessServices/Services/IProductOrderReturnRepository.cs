using DataAccessServices.Services.Base;
using DomainModel.DTO.ProductOrderReturn;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IProductOrderReturnRepository : IBaseRepositorySearchable<ProductOrderReturn,int, ProductOrderReturn, ProductOrderReturnComplexResult>
    {
        
    }
}
