using DomainModel.Assist;
using DomainModel.DTO.ProductCart;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IProductCartBusiness
    {
        OperationResult Add(ProductCart model);
        OperationResult Update(ProductCart model);
        OperationResult Delete(int id);
        ProductCart Get(int id);
        List<ProductCart> GetAll();
        ProductCartComplexResult Search(ProductCart sm, out int recordCount);

    }
}
