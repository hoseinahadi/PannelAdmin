using DomainModel.Assist;
using DomainModel.DTO.OrderDiscount;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IOrderDiscountBusiness
    {
        OperationResult Add(OrderDiscount model);
        OperationResult Update(OrderDiscount model);
        OperationResult Delete(int id);
        OrderDiscount Get(int id);
        List<OrderDiscount> GetAll();
        OrderDiscountComplexResult Search(OrderDiscount sm, out int recordCount);

    }
}
