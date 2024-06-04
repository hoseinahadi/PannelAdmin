using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OrderDiscount;
using DomainModel.DTO.OrderProduct;
using DomainModel.Models;

namespace Business.IMP
{
    public class OrderProductBusiness : IOrderProductBusiness
    {
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderProductBusiness(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
        }
        public OperationResult Add(OrderProduct model)
        {
            return _orderProductRepository.Add(model);
        }

        public OperationResult Update(OrderProduct model)
        {
            return _orderProductRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _orderProductRepository.Delete(id);
        }

        public OrderProduct Get(int id)
        {
            return _orderProductRepository.Get(id);
        }

        public List<OrderProduct> GetAll()
        {
            return _orderProductRepository.GetAll();
        }

        public OrderProductComplexResult Search(OrderProduct sm, out int recordCount)
        {
            return _orderProductRepository.Search(sm, out recordCount);
        }
    }
}
