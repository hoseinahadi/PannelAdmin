using DomainModel.Assist;
using DomainModel.DTO.Order;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IOrderBusiness
    {
        OperationResult Add(OrderAddEditModel model);
        OperationResult Update(OrderAddEditModel model);
        OperationResult Delete(int id);
        OrderAddEditModel Get(int id);
        List<Order> GetAll();
        OrderComplexResults Search(OrderSearchModel sm, out int recordCount);
    }
}
