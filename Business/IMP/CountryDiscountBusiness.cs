using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.CountryDiscount;
using DomainModel.Models;

namespace Business.IMP
{
    public class CountryDiscountBusiness:ICountryDiscountBusiness
    {
        private readonly ICountryDiscountRepository _countryDiscountRepository;

        public CountryDiscountBusiness(ICountryDiscountRepository countryDiscountRepository)
        {
            _countryDiscountRepository = countryDiscountRepository;
        }
        public OperationResult Add(CountryDiscount model)
        {
            return _countryDiscountRepository.Add(model);
        }

        public OperationResult Update(CountryDiscount model)
        {
            return _countryDiscountRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _countryDiscountRepository.Delete(id);
        }

        public CountryDiscount Get(int id)
        {
            return _countryDiscountRepository.Get(id);
        }

        public List<CountryDiscount> GetAll()
        {
           return _countryDiscountRepository.GetAll();
        }

        public CountryDiscountComplexResult Search(CountryDiscount sm, out int recordCount)
        {
            return _countryDiscountRepository.Search(sm, out recordCount);
        }
    }
}
