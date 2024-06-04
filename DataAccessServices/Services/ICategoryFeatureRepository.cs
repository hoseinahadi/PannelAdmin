using DataAccessServices.Services.Base;
using DomainModel.DTO.CategoryFeature;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ICategoryFeatureRepository : IBaseRepositorySearchable<CategoryFeature, int, CategoryFeature, CategoryFeatureComplexResult>
    {
        
    }
}
