using DomainModel.Assist;
using DomainModel.DTO.Supplier;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ISupplierBusiness
    {
        OperationResult Add(SupplierAddEditModel model);
        OperationResult Update(SupplierAddEditModel model);
        OperationResult Delete(int id);
        SupplierAddEditModel Get(int id);
        List<Supplier> GetAll();
        SupplierComplexResults Search(SupplierSearchModel sm, out int recordCount);
    }
}
