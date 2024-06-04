using DomainModel.Assist;
using DomainModel.DTO.ProductSupplier;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IProductSupplierBusiness
    {
        OperationResult Add(ProductSupplier model);
        OperationResult Update(ProductSupplier model);
        OperationResult Delete(int id);
        ProductSupplier Get(int id);
        List<ProductSupplier> GetAll();
        ProductSupplierComplexResult Search(ProductSupplier sm, out int recordCount);

    }
}
