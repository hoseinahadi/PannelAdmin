using DataAccessServices.Services.Base;
using DomainModel.DTO.GuestUser;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IGuestUserRepository:IBaseRepositorySearchable<GuestUser,int,GuestUserSearchModel,GuestUserComplexResults>
    {
    }
}
