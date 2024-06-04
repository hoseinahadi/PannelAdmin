using DataAccessServices.Services.Base;
using DomainModel.DTO.ProductFeature;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IProductFeatureRepository : IBaseRepositorySearchable<ProductFeature,int, ProductFeature, ProductFeatureComplexResult>
    {
        
    }
}
