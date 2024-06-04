using DataAccessServices.Services.Base;
using DomainModel.DTO.UserDiscount;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IUserDiscountRepository : IBaseRepositorySearchable<UserDiscount,int,UserDiscount,UserDiscountComplexResult>
    {
        
    }
}
