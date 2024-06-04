using DataAccessServices.Services.Base;
using DomainModel.DTO.ProductDiscount;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IProductDiscountRepository : IBaseRepositorySearchable<ProductDiscount,int, ProductDiscount, ProductDiscountComplexResult>
    {
        
    }
}
