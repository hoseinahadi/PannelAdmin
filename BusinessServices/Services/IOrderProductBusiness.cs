using DomainModel.Assist;
using DomainModel.Assist;
using DomainModel.DTO.OrderProduct;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IOrderProductBusiness
    {
        OperationResult Add(OrderProduct model);
        OperationResult Update(OrderProduct model);
        OperationResult Delete(int id);
        OrderProduct Get(int id);
        List<OrderProduct> GetAll();
        OrderProductComplexResult Search(OrderProduct sm, out int recordCount);
    }
}
