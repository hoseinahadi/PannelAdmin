using DataAccessServices.Services.Base;
using DomainModel.DTO.CountryDiscount;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ICountryDiscountRepository : IBaseRepositorySearchable<CountryDiscount,int,CountryDiscount,CountryDiscountComplexResult>
    {
        
    }
}
