using DataAccessServices.Services.Base;
using DomainModel.DTO.ProductSupplier;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IProductSupplierRepository : IBaseRepositorySearchable<ProductSupplier,int, ProductSupplier, ProductSupplierComplexResult>
    {
        
    }
}
