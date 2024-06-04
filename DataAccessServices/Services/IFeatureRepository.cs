using DataAccessServices.Services.Base;
using DomainModel.DTO.Feature;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IFeatureRepository:IBaseRepositorySearchable<Feature,int,FeatureSearchModel,FeatureComplexResults>
    {
        bool HasFeatureName(string name);
    }
}
