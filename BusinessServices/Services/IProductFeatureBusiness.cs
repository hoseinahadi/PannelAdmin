using DomainModel.Assist;
using DomainModel.DTO.ProductFeature;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IProductFeatureBusiness
    {
        OperationResult Add(ProductFeature model);
        OperationResult Update(ProductFeature model);
        OperationResult Delete(int id);
        ProductFeature Get(int id);
        List<ProductFeature> GetAll();
        ProductFeatureComplexResult Search(ProductFeature sm, out int recordCount);

    }
}
