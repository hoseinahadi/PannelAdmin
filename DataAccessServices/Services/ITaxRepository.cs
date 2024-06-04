using DataAccessServices.Services.Base;
using DomainModel.DTO.Tax;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ITaxRepository:IBaseRepositorySearchable<Tax,int,TaxSearchModel,TaxComplexResults>
    {
        bool HasTax(string name);
    }
}
