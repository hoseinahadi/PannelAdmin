using DataAccessServices.Services.Base;
using DomainModel.DTO.Carrier;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ICarrierRepository:IBaseRepositorySearchable<Carrier,int,CarrierSearchModel,CarrierComplexResults>
    {
        
    }
}
