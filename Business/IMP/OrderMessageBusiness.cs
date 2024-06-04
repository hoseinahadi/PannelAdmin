using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OrderMessage;
using DomainModel.Models;

namespace Business.IMP
{
    public class OrderMessageBusiness:IOrderMessageBusiness
    {
        private readonly IOrderMessageRepository _orderMessageRepository;

        public OrderMessageBusiness(IOrderMessageRepository orderMessageRepository)
        {
            _orderMessageRepository = orderMessageRepository;
        }
        public OperationResult Add(OrderMessage model)
        {
            return _orderMessageRepository.Add(model);
        }

        public OperationResult Update(OrderMessage model)
        {
            return _orderMessageRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _orderMessageRepository.Delete(id);
        }

        public OrderMessage Get(int id)
        {
            return _orderMessageRepository.Get(id);
        }

        public List<OrderMessage> GetAll()
        {
            return _orderMessageRepository.GetAll();
        }

        public OrderMessageComplexResult Search(OrderMessage sm, out int recordCount)
        {
            return _orderMessageRepository.Search(sm, out recordCount);
        }
    }
}
