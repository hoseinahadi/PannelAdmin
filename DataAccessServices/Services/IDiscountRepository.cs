using DataAccessServices.Services.Base;
using DomainModel.DTO.Discount;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IDiscountRepository:IBaseRepositorySearchable<Discount,int,DiscountSearchModel,DiscountComplexResults>
    {
    }
}
