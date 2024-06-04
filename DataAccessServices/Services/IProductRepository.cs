using DataAccessServices.Services.Base;
using DomainModel.DTO.Product;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IProductRepository:IBaseRepositorySearchable<Product,int,ProductSearchModel,ProductComplexResults>
    {
        bool HasProduct(string name);
    }
}
