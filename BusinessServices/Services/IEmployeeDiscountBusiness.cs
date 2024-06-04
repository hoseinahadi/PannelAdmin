using DomainModel.Assist;
using DomainModel.DTO.EmployeeDiscount;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IEmployeeDiscountBusiness
    {
        OperationResult Add(EmployeeDiscount model);
        OperationResult Update(EmployeeDiscount model);
        OperationResult Delete(int id);
        EmployeeDiscount Get(int id);
        List<EmployeeDiscount> GetAll();
        EmployeeDiscountComplexResult Search(EmployeeDiscount sm, out int recordCount);

    }
}
