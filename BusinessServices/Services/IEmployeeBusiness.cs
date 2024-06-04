using DomainModel.Assist;
using DomainModel.DTO.Employee;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IEmployeeBusiness
    {
        OperationResult Add(EmployeeAddOrEditModel model);
        OperationResult Update(EmployeeAddOrEditModel model);
        OperationResult Delete(int id);
        EmployeeAddOrEditModel Get(int id);
        List<Employee> GetAll();
        EmployeeComplexResults Search(EmployeeSearchModel sm, out int recordCount);
    }
}
