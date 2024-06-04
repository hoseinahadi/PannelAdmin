using DataAccessServices.Services.Base;
using DomainModel.DTO.Delivery;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IDeliveryRepository:IBaseRepositorySearchable<Delivery,int,DeliverySearchModel,DeliveryComplexResults>
    {
    }
}
