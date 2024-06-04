using DataAccessServices.Services.Base;
using DomainModel.DTO.Access;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IAccessRepository:IBaseRepositorySearchable<Access,int,AccessSearchModel, AccessComplexResult>
    {
        bool HasRelatedEmployee(int Id);
        bool HasDuplicateAccess(string name);
    }
}
