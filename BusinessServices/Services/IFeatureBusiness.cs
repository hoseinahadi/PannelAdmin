using DomainModel.Assist;
using DomainModel.DTO.Feature;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IFeatureBusiness
    {
        OperationResult Add(FeatureAddEditModel model);
        OperationResult Update(FeatureAddEditModel model);
        OperationResult Delete(int id);
        FeatureAddEditModel Get(int id);
        List<Feature> GetAll();
        FeatureComplexResults Search(FeatureSearchModel sm, out int recordCount);
    }
}
