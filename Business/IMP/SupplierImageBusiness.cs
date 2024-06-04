using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.SupplierImage;
using DomainModel.Models;

namespace Business.IMP
{
    public class SupplierImageBusiness:ISupplierImageBusiness
    {
        private readonly ISupplierImageRepository _supplierImageRepository;

        public SupplierImageBusiness(ISupplierImageRepository supplierImageRepository)
        {
            _supplierImageRepository = supplierImageRepository;
        }
        public OperationResult Add(SupplierImage model)
        {
            return _supplierImageRepository.Add(model);
        }

        public OperationResult Update(SupplierImage model)
        {
            return _supplierImageRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _supplierImageRepository.Delete(id);
        }

        public SupplierImage Get(int id)
        {
            return _supplierImageRepository.Get(id);
        }

        public List<SupplierImage> GetAll()
        {
            return _supplierImageRepository.GetAll();
        }

        public SupplierImageComplexResult Search(SupplierImage sm, out int recordCount)
        {
            return _supplierImageRepository.Search(sm, out recordCount);
        }
    }
}
