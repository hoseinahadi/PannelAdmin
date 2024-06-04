using DataAccessServices.Services.Base;
using DomainModel.DTO.CategoryDiscount;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ICategoryDiscountRepository : IBaseRepositorySearchable<CategoryDiscount, int, CategoryDiscount, CategoryDiscountComplexResult>
    {
        
    }
}
