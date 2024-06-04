using DomainModel.Assist;
using DomainModel.DTO.Cart;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ICartBusiness
    {
        OperationResult Add(CartAddOrEditModel model);
        OperationResult Update(CartAddOrEditModel model);
        OperationResult Delete(int id);
        CartAddOrEditModel Get(int id);
        List<Cart> GetAll();
    }
}
