using DataAccessServices.Services.Base;
using DomainModel.DTO.Country;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ICountryRepository:IBaseRepositorySearchable<Country,int,CountrySearchModel,CountryComplexResults>
    {
        bool DuplicateCountry(string name);
    }
}
