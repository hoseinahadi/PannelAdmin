using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.EmployeeMessage;
using DomainModel.Models;

namespace Business.IMP
{
    public class EmployeeMessageBusiness:IEmployeeMessageBusiness
    {
        private readonly IEmployeeMessageRepository _employeeMessageRepository;

        public EmployeeMessageBusiness(IEmployeeMessageRepository employeeMessageRepository)
        {
            _employeeMessageRepository = employeeMessageRepository;
        }
        public OperationResult Add(EmployeeMessage model)
        {
            return _employeeMessageRepository.Add(model);
        }

        public OperationResult Update(EmployeeMessage model)
        {
            return _employeeMessageRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _employeeMessageRepository.Delete(id);
        }

        public EmployeeMessage Get(int id)
        {
            return _employeeMessageRepository.Get(id);
        }

        public List<EmployeeMessage> GetAll()
        {
            return _employeeMessageRepository.GetAll();
        }

        public EmployeeMessageComplexResult Search(EmployeeMessage sm, out int recordCount)
        {
            return _employeeMessageRepository.Search(sm, out recordCount);
        }
    }
}
