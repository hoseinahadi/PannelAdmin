using DomainModel.Assist;
using DomainModel.DTO.Product;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IProductBusiness
    {
        OperationResult Add(ProductAddEditModel model);
        OperationResult Update(ProductAddEditModel model);
        OperationResult Delete(int id);
        ProductAddEditModel Get(int id);
        List<Product> GetAll();
        ProductComplexResults Search(ProductSearchModel sm, out int recordCount);
    }
}
