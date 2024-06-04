using DataAccessServices.Services.Base;
using DomainModel.DTO.EmployeeDiscount;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IEmployeeDiscountRepository : IBaseRepositorySearchable<EmployeeDiscount, int, EmployeeDiscount, EmployeeDiscountComplexResult>
    {
        
    }
}
