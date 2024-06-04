using DomainModel.Assist;
using DomainModel.DTO.CountryDiscount;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ICountryDiscountBusiness
    {
        OperationResult Add(CountryDiscount model);
        OperationResult Update(CountryDiscount model);
        OperationResult Delete(int id);
        CountryDiscount Get(int id);
        List<CountryDiscount> GetAll();
        CountryDiscountComplexResult Search(CountryDiscount sm, out int recordCount);

    }
}
