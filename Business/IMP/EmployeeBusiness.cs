using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Connection;
using DomainModel.DTO.Employee;
using DomainModel.Models;

namespace Business.IMP
{
    public class EmployeeBusiness:IEmployeeBusiness
    {
        private readonly IEmployeeRepository repo;

        public EmployeeBusiness(IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        private Employee ToModel(EmployeeAddOrEditModel addOrEdit)
        {
            return new Employee
            {
                AccessId = addOrEdit.AccessId,
                FirstName = addOrEdit.FirstName,
                LastName = addOrEdit.LastName,
                Email = addOrEdit.Email,
                Active = addOrEdit.Active,
                EmployeeId = addOrEdit.EmployeeId,
                ParentId = addOrEdit.ParentId,
                Password = addOrEdit.Password,


                RoleId = addOrEdit.RoleId,
            };
        }
        private EmployeeAddOrEditModel ToAddEditModel(Employee model)
        {
            return new EmployeeAddOrEditModel
            {
                AccessId = model.AccessId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Active = model.Active,
                EmployeeId = model.EmployeeId,
                ParentId = model.ParentId,
                Password = model.Password,
                RoleId = model.RoleId
            };
        }
        public OperationResult Add(EmployeeAddOrEditModel model)
        {
            return repo.Add(ToModel(model));

        }

        public OperationResult Update(EmployeeAddOrEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public EmployeeAddOrEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Employee> GetAll()
        {
            return repo.GetAll();
        }

        public EmployeeComplexResults Search(EmployeeSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
