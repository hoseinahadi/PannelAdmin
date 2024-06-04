using DomainModel.Assist;
using DomainModel.DTO.ProductCategory;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IProductCategoryBusiness
    {
        OperationResult Add(ProductCategory model);
        OperationResult Update(ProductCategory model);
        OperationResult Delete(int id);
        ProductCategory Get(int id);
        List<ProductCategory> GetAll();
        ProductCategoryComplexResult Search(ProductCategory sm, out int recordCount);

    }
}
