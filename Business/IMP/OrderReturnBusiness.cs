using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Order;
using DomainModel.DTO.OrderReturn;
using DomainModel.Models;

namespace Business.IMP
{
    public class OrderReturnBusiness:IOrderReturnBusiness
    {
        private readonly IOrderReturnRepository repo;

        public OrderReturnBusiness(IOrderReturnRepository repo)
        {
            this.repo = repo;
        }
        private OrderReturn ToModel(OrderReturnAddEditModel addOrEdit)
        {
            return new OrderReturn
            {
                AddressId = addOrEdit.AddressId,
                CurrencyId = addOrEdit.CurrencyId,
                EmployeeId = addOrEdit.EmployeeId,
                OrderId = addOrEdit.OrderId,
                State = addOrEdit.State,
                AddDate = addOrEdit.AddDate,
                OrderReturnId = addOrEdit.OrderReturnId,
                Question = addOrEdit.Question,


            };
        }
        private OrderReturnAddEditModel ToAddEditModel(OrderReturn model)
        {
            return new OrderReturnAddEditModel
            {
                AddressId = model.AddressId,
                CurrencyId = model.CurrencyId,
                EmployeeId = model.EmployeeId,
                OrderId = model.OrderId,
                State = model.State,
                AddDate = model.AddDate,
                OrderReturnId = model.OrderReturnId,
                Question = model.Question,

            };
        }
        public OperationResult Add(OrderReturnAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(OrderReturnAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public OrderReturnAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<OrderReturn> GetAll()
        {
            return repo.GetAll();
        }

        public OrderReturnComplexResults Search(OrderReturnSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
