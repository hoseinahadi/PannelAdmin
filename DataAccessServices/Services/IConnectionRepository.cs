using DataAccessServices.Services.Base;
using DomainModel.DTO.Connection;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IConnectionRepository:IBaseRepositorySearchable<Connection,int,ConnectionSearchModel,ConnectionComplexResult>
    {
    }
}
