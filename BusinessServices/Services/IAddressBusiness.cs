using DomainModel.Assist;
using DomainModel.DTO.Address;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IAddressBusiness
    {
        OperationResult Add(AddressAddOrEditModel model);
        OperationResult Update(AddressAddOrEditModel model);
        OperationResult Delete(int id);
        AddressAddOrEditModel Get(int id);
        List<Address> GetAll();
        AddressComplexResult Search(AddressSearchModel sm, out int recordCount);
    }
}
