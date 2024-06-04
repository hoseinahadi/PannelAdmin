using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Supplier;
using DomainModel.DTO.Tax;
using DomainModel.Models;

namespace Business.IMP
{
    public class TaxBusiness:ITaxBusiness
    {
        private readonly ITaxRepository repo;

        public TaxBusiness(ITaxRepository repo)
        {
            this.repo = repo;
        }
        private Tax ToModel(TaxAddEditModel addOrEdit)
        {
            return new Tax
            {
                TaxId = addOrEdit.TaxId,
                TaxName = addOrEdit.TaxName,
                TaxPercent = addOrEdit.TaxPercent,

            };
        }
        private TaxAddEditModel ToAddEditModel(Tax model)
        {
            return new TaxAddEditModel
            {
                TaxId = model.TaxId,
                TaxName = model.TaxName,
                TaxPercent = model.TaxPercent,

            };
        }
        public OperationResult Add(TaxAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(TaxAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public TaxAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Tax> GetAll()
        {
            return repo.GetAll();
        }

        public TaxComplexResults Search(TaxSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
