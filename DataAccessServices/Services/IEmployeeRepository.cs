using DataAccessServices.Services.Base;
using DomainModel.DTO.Employee;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IEmployeeRepository:IBaseRepositorySearchable<Employee,int,EmployeeSearchModel,EmployeeComplexResults>
    {
    }
}
