using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OrderReturnMessage;
using DomainModel.Models;

namespace Business.IMP
{
    public class OrderReturnMessageBusiness:IOrderReturnMessageBusiness
    {
        private readonly IOrderReturnMessageRepository _orderReturnMessageRepository;

        public OrderReturnMessageBusiness(IOrderReturnMessageRepository orderReturnMessageRepository)
        {
            _orderReturnMessageRepository = orderReturnMessageRepository;
        }
        public OperationResult Add(OrderReturnMessage model)
        {
            return _orderReturnMessageRepository.Add(model);
        }

        public OperationResult Update(OrderReturnMessage model)
        {
            return _orderReturnMessageRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _orderReturnMessageRepository.Delete(id);
        }

        public OrderReturnMessage Get(int id)
        {
            return _orderReturnMessageRepository.Get(id);
        }

        public List<OrderReturnMessage> GetAll()
        {
            return _orderReturnMessageRepository.GetAll();
        }

        public OrderReturnMessageComplexResult Search(OrderReturnMessage sm, out int recordCount)
        {
            return _orderReturnMessageRepository.Search(sm, out recordCount);
        }
    }
}
