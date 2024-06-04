using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OrderDiscount;
using DomainModel.Models;

namespace Business.IMP
{
    public class OrderDiscountBusiness:IOrderDiscountBusiness
    {
        private readonly IOrderDiscountRepository _orderDiscountRepository;

        public OrderDiscountBusiness(IOrderDiscountRepository orderDiscountRepository)
        {
            _orderDiscountRepository = orderDiscountRepository;
        }
        public OperationResult Add(OrderDiscount model)
        {
            return _orderDiscountRepository.Add(model);
        }

        public OperationResult Update(OrderDiscount model)
        {
            return _orderDiscountRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _orderDiscountRepository.Delete(id);
        }

        public OrderDiscount Get(int id)
        {
            return _orderDiscountRepository.Get(id);
        }

        public List<OrderDiscount> GetAll()
        {
            return _orderDiscountRepository.GetAll();
        }

        public OrderDiscountComplexResult Search(OrderDiscount sm, out int recordCount)
        {
            return _orderDiscountRepository.Search(sm, out recordCount);
        }
    }
}
