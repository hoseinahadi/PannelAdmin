using DomainModel.Assist;
using DomainModel.DTO.Delivery;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IDeliveryBusiness
    {
        OperationResult Add(DeliveryAddOrEditModel model);
        OperationResult Update(DeliveryAddOrEditModel model);
        OperationResult Delete(int id);
        DeliveryAddOrEditModel Get(int id);
        List<Delivery> GetAll();
        DeliveryComplexResults Search(DeliverySearchModel sm, out int recordCount);
    }
}
