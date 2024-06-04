using DataAccessServices.Services.Base;
using DomainModel.DTO.EmployeeMessage;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IEmployeeMessageRepository : IBaseRepositorySearchable<EmployeeMessage, int, EmployeeMessage, EmployeeMessageComplexResult>
    {
        
    }
}
