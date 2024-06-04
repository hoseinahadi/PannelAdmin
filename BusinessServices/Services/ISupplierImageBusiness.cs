using DomainModel.Assist;
using DomainModel.DTO.SupplierImage;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ISupplierImageBusiness
    {
        OperationResult Add(SupplierImage model);
        OperationResult Update(SupplierImage model);
        OperationResult Delete(int id);
        SupplierImage Get(int id);
        List<SupplierImage> GetAll();
        SupplierImageComplexResult Search(SupplierImage sm, out int recordCount);

    }
}
