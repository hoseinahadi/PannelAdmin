using DomainModel.Assist;
using DomainModel.DTO.CategoryDiscount;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ICategoryDiscountBusiness
    {
        OperationResult Add(CategoryDiscount model);
        OperationResult Update(CategoryDiscount model);
        OperationResult Delete(int id);
        CategoryDiscount Get(int id);
        List<CategoryDiscount> GetAll();
        CategoryDiscountComplexResult Search(CategoryDiscount sm, out int recordCount);
    }
}
