using DataAccessServices.Services.Base;
using DomainModel.DTO.ProductCategory;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IProductCategoryRepository : IBaseRepositorySearchable<ProductCategory,int, ProductCategory, ProductCategoryComplexResult>
    {
    }
}
