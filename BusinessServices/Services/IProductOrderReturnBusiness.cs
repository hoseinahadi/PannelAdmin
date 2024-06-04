using DomainModel.Assist;
using DomainModel.DTO.ProductOrderReturn;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IProductOrderReturnBusiness
    {
        OperationResult Add(ProductOrderReturn model);
        OperationResult Update(ProductOrderReturn model);
        OperationResult Delete(int id);
        ProductOrderReturn Get(int id);
        List<ProductOrderReturn> GetAll();
        ProductOrderReturnComplexResult Search(ProductOrderReturn sm, out int recordCount);

    }
}
