using DomainModel.Assist;
using DomainModel.DTO.CategoryFeature;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ICategoryFeatureBusiness
    {
        OperationResult Add(CategoryFeature model);
        OperationResult Update(CategoryFeature model);
        OperationResult Delete(int id);
        CategoryFeature Get(int id);
        List<CategoryFeature> GetAll();
        CategoryFeatureComplexResult Search(CategoryFeature sm, out int recordCount);

    }
}
