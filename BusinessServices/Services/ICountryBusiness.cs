using DomainModel.Assist;
using DomainModel.DTO.Country;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ICountryBusiness
    {
        OperationResult Add(CountryAddOeEditModel model);
        OperationResult Update(CountryAddOeEditModel model);
        OperationResult Delete(int id);
        CountryAddOeEditModel Get(int id);
        List<Country> GetAll();
        CountryComplexResults Search(CountrySearchModel sm, out int recordCount);
    }
}
