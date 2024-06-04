using DomainModel.Assist;
using DomainModel.DTO.UserDiscount;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IUserDiscountBusiness
    {
        OperationResult Add(UserDiscount model);
        OperationResult Update(UserDiscount model);
        OperationResult Delete(int id);
        UserDiscount Get(int id);
        List<UserDiscount> GetAll();
        UserDiscountComplexResult Search(UserDiscount sm, out int recordCount);

    }
}
