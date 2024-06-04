using DomainModel.Assist;
using DomainModel.DTO.OrderReturn;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IOrderReturnBusiness
    {
        OperationResult Add(OrderReturnAddEditModel model);
        OperationResult Update(OrderReturnAddEditModel model);
        OperationResult Delete(int id);
        OrderReturnAddEditModel Get(int id);
        List<OrderReturn> GetAll();
        OrderReturnComplexResults Search(OrderReturnSearchModel sm, out int recordCount);
    }
}
