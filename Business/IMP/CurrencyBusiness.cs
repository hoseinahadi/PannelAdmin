using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Country;
using DomainModel.DTO.Currency;
using DomainModel.Models;

namespace Business.IMP
{
    public class CurrencyBusiness:ICurrencyBusiness
    {
        private readonly ICurrencyRepository repo;

        public CurrencyBusiness(ICurrencyRepository repo)
        {
            this.repo = repo;
        }
        private Currency ToModel(CurrencyAddOrEditModel addOrEdit)
        {
            return new Currency
            {
                ConversionRate = addOrEdit.ConversionRate,
                CurrencyId = addOrEdit.CurrencyId,
                CurrencyName = addOrEdit.CurrencyName,

                
            };
        }
        private CurrencyAddOrEditModel ToAddEditModel(Currency model)
        {
            return new CurrencyAddOrEditModel
            {
                ConversionRate = model.ConversionRate,
                CurrencyId = model.CurrencyId,
                CurrencyName = model.CurrencyName,

            };
        }
        public OperationResult Add(CurrencyAddOrEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(CurrencyAddOrEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public CurrencyAddOrEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Currency> GetAll()
        {
            return repo.GetAll();
        }

        public CurrencyComplexResults Search(CurrencySearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
