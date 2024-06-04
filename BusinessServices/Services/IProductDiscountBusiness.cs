using DomainModel.Assist;
using DomainModel.DTO.ProductDiscount;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IProductDiscountBusiness
    {
        OperationResult Add(ProductDiscount model);
        OperationResult Update(ProductDiscount model);
        OperationResult Delete(int id);
        ProductDiscount Get(int id);
        List<ProductDiscount> GetAll();
        ProductDiscountComplexResult Search(ProductDiscount sm, out int recordCount);

    }
}
