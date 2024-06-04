using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Product;
using DomainModel.DTO.Supplier;
using DomainModel.Models;

namespace Business.IMP
{
    public class SupplierBusiness:ISupplierBusiness
    {
        private readonly ISupplierRepository repo;

        public SupplierBusiness(ISupplierRepository repo)
        {
            this.repo = repo;
        }
        private Supplier ToModel(SupplierAddEditModel addOrEdit)
        {
            return new Supplier
            {
                Note = addOrEdit.Note,
                SupplierName = addOrEdit.SupplierName,
                PhoneNumber = addOrEdit.PhoneNumber,
                SupplierId = addOrEdit.SupplierId,

            };
        }
        private SupplierAddEditModel ToAddEditModel(Supplier model)
        {
            return new SupplierAddEditModel
            {
                Note = model.Note,
                SupplierName = model.SupplierName,
                PhoneNumber = model.PhoneNumber,
                SupplierId = model.SupplierId,

            };
        }
        public OperationResult Add(SupplierAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(SupplierAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public SupplierAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Supplier> GetAll()
        {
            return repo.GetAll();
        }

        public SupplierComplexResults Search(SupplierSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
