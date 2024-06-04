using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Cart;
using DomainModel.DTO.Connection;
using DomainModel.DTO.Country;
using DomainModel.Models;

namespace Business.IMP
{
    public class CountryBusiness:ICountryBusiness
    {
        private readonly ICountryRepository repo;

        public CountryBusiness(ICountryRepository repo)
        {
            this.repo = repo;
        }
        private Country ToModel(CountryAddOeEditModel addOrEdit)
        {
            return new Country
            {
                CountryCode = addOrEdit.CountryCode,
                CountryName = addOrEdit.CountryName,
                CountryId = addOrEdit.CountryId,


            };
        }
        private CountryAddOeEditModel ToAddEditModel(Country model)
        {
            return new CountryAddOeEditModel
            {
                CountryCode = model.CountryCode,
                CountryName = model.CountryName,
                CountryId = model.CountryId,

            };
        }
        public OperationResult Add(CountryAddOeEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(CountryAddOeEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public CountryAddOeEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Country> GetAll()
        {
            return repo.GetAll();
        }

        public CountryComplexResults Search(CountrySearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
