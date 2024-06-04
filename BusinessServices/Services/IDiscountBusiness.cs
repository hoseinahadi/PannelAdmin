using DomainModel.Assist;
using DomainModel.DTO.Discount;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IDiscountBusiness
    {
        OperationResult Add(DiscountAddOrEditModel model);
        OperationResult Update(DiscountAddOrEditModel model);
        OperationResult Delete(int id);
        DiscountAddOrEditModel Get(int id);
        List<Discount> GetAll();
        DiscountComplexResults Search(DiscountSearchModel sm, out int recordCount);
    }
}
