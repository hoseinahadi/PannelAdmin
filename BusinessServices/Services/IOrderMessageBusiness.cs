using DomainModel.Assist;
using DomainModel.DTO.OrderMessage;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IOrderMessageBusiness
    {
        OperationResult Add(OrderMessage model);
        OperationResult Update(OrderMessage model);
        OperationResult Delete(int id);
        OrderMessage Get(int id);
        List<OrderMessage> GetAll();
        OrderMessageComplexResult Search(OrderMessage sm, out int recordCount);

    }
}
