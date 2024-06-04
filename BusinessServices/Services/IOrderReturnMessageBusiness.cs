using DomainModel.Assist;
using DomainModel.DTO.OrderReturnMessage;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IOrderReturnMessageBusiness
    {
        OperationResult Add(OrderReturnMessage model);
        OperationResult Update(OrderReturnMessage model);
        OperationResult Delete(int id);
        OrderReturnMessage Get(int id);
        List<OrderReturnMessage> GetAll();
        OrderReturnMessageComplexResult Search(OrderReturnMessage sm, out int recordCount);

    }
}
