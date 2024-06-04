using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OpSystem;
using DomainModel.DTO.Order;
using DomainModel.Models;

namespace Business.IMP
{
    public class OrderBusiness:IOrderBusiness
    {
        private readonly IOrderRepository repo;

        public OrderBusiness(IOrderRepository repo)
        {
            this.repo = repo;
        }
        private Order ToModel(OrderAddEditModel addOrEdit)
        {
            return new Order
            {
                UserId = addOrEdit.UserId,
                AddressId = addOrEdit.AddressId,
                CurrencyId = addOrEdit.CurrencyId,
                EmployeeId = addOrEdit.EmployeeId,
                OrderId = addOrEdit.OrderId,
                Payment = addOrEdit.Payment,
                ProductCount = addOrEdit.ProductCount,
                SecureKey = addOrEdit.SecureKey,
                ShoppingPhone = addOrEdit.ShoppingPhone,
                AddDate = addOrEdit.OrderData,
            };
        }
        private OrderAddEditModel ToAddEditModel(Order model)
        {
            return new OrderAddEditModel
            {
                UserId = model.UserId,
                AddressId = model.AddressId,
                CurrencyId = model.CurrencyId,
                EmployeeId = model.EmployeeId.Value,
                OrderData = model.AddDate,
                OrderId = model.OrderId,
                Payment = model.Payment,
                ProductCount = model.ProductCount,
                SecureKey = model.SecureKey,
                ShoppingPhone = model.ShoppingPhone,
                
            };
        }


        public OperationResult Add(OrderAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(OrderAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public OrderAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Order> GetAll()
        {
            return repo.GetAll();
        }

        public OrderComplexResults Search(OrderSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
