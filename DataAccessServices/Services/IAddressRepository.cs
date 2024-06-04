using DataAccessServices.Services.Base;
using DomainModel.DTO.Address;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IAddressRepository:IBaseRepositorySearchable<Address, int,AddressSearchModel,AddressComplexResult>
    {
        
    }
}
