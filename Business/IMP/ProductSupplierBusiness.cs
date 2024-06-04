using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProductSupplier;
using DomainModel.Models;

namespace Business.IMP
{
    public class ProductSupplierBusiness:IProductSupplierBusiness
    {
        private readonly IProductSupplierRepository _productSupplierRepository;

        public ProductSupplierBusiness(IProductSupplierRepository productSupplierRepository)
        {
            _productSupplierRepository = productSupplierRepository;
        }
        public OperationResult Add(ProductSupplier model)
        {
            return _productSupplierRepository.Add(model);
        }

        public OperationResult Update(ProductSupplier model)
        {
            return _productSupplierRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _productSupplierRepository.Delete(id);
        }

        public ProductSupplier Get(int id)
        {
            return _productSupplierRepository.Get(id);
        }

        public List<ProductSupplier> GetAll()
        {
            return _productSupplierRepository.GetAll();
        }

        public ProductSupplierComplexResult Search(ProductSupplier sm, out int recordCount)
        {
            return _productSupplierRepository.Search(sm, out recordCount);
        }
    }
}
