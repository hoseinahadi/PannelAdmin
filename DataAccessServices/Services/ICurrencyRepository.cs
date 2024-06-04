using DataAccessServices.Services.Base;
using DomainModel.DTO.Currency;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ICurrencyRepository:IBaseRepositorySearchable<Currency,int,CurrencySearchModel,CurrencyComplexResults>
    {
        bool HasCurrency(string name);
    }
}
