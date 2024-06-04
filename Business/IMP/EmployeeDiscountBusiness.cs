using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.EmployeeDiscount;
using DomainModel.Models;

namespace Business.IMP
{
    public class EmployeeDiscountBusiness:IEmployeeDiscountBusiness
    {
        private readonly IEmployeeDiscountRepository _employeeDiscountRepository;

        public EmployeeDiscountBusiness(IEmployeeDiscountRepository employeeDiscountRepository)
        {
            this._employeeDiscountRepository = employeeDiscountRepository;
        }
        public OperationResult Add(EmployeeDiscount model)
        {
            return _employeeDiscountRepository.Add(model);
        }

        public OperationResult Update(EmployeeDiscount model)
        {
            return _employeeDiscountRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _employeeDiscountRepository.Delete(id);
        }

        public EmployeeDiscount Get(int id)
        {
            return _employeeDiscountRepository.Get(id);
        }

        public List<EmployeeDiscount> GetAll()
        {
            return _employeeDiscountRepository.GetAll();
        }

        public EmployeeDiscountComplexResult Search(EmployeeDiscount sm, out int recordCount)
        {
            return _employeeDiscountRepository.Search(sm, out recordCount);
        }
    }
}
