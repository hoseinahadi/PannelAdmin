using DataAccessServices.Services.Base;
using DomainModel.DTO.ProductCart;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IProductCartRepository : IBaseRepositorySearchable<ProductCart,int, ProductCart, ProductCartComplexResult>
    {
        
    }
}
