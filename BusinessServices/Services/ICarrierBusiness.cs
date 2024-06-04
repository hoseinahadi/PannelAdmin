using DomainModel.Assist;
using DomainModel.DTO.Carrier;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ICarrierBusiness
    {
        OperationResult Add(CarrierAddEditModel model);
        OperationResult Update(CarrierAddEditModel model);
        OperationResult Delete(int id);
        CarrierAddEditModel Get(int id);
        List<Carrier> GetAll();
        CarrierComplexResults Search(CarrierSearchModel sm, out int recordCount);
    }
}
