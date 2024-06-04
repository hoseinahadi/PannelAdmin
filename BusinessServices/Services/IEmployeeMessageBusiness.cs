using DomainModel.Assist;
using DomainModel.DTO.EmployeeMessage;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IEmployeeMessageBusiness
    {
        OperationResult Add(EmployeeMessage model);
        OperationResult Update(EmployeeMessage model);
        OperationResult Delete(int id);
        EmployeeMessage Get(int id);
        List<EmployeeMessage> GetAll();
        EmployeeMessageComplexResult Search(EmployeeMessage sm, out int recordCount);

    }
}
