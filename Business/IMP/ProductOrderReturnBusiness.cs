using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProductOrderReturn;
using DomainModel.Models;

namespace Business.IMP
{
    public class ProductOrderReturnBusiness:IProductOrderReturnBusiness
    {
        private readonly IProductOrderReturnRepository _productOrderReturnRepository;

        public ProductOrderReturnBusiness(IProductOrderReturnRepository productOrderReturnRepository)
        {
            _productOrderReturnRepository = productOrderReturnRepository;
        }
        public OperationResult Add(ProductOrderReturn model)
        {
            return _productOrderReturnRepository.Add(model);
        }

        public OperationResult Update(ProductOrderReturn model)
        {
            return _productOrderReturnRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _productOrderReturnRepository.Delete(id);
        }

        public ProductOrderReturn Get(int id)
        {
            return _productOrderReturnRepository.Get(id);
        }

        public List<ProductOrderReturn> GetAll()
        {
            return _productOrderReturnRepository.GetAll();
        }

        public ProductOrderReturnComplexResult Search(ProductOrderReturn sm, out int recordCount)
        {
            return _productOrderReturnRepository.Search(sm, out recordCount);
        }
    }
}
