using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;


using DomainModel.Assist;
using DomainModel.DTO.ProductCart;
using DomainModel.Models;

namespace Business.IMP
{
    public class ProductCartBusiness:IProductCartBusiness
    {
        private readonly IProductCartRepository _productCartRepository;

        public ProductCartBusiness(IProductCartRepository productCartRepository)
        {
            _productCartRepository = productCartRepository;
        }
        public OperationResult Add(ProductCart model)
        {
            return _productCartRepository.Add(model);
        }

        public OperationResult Update(ProductCart model)
        {
            return _productCartRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _productCartRepository.Delete(id);
        }

        public ProductCart Get(int id)
        {
            return _productCartRepository.Get(id);
        }

        public List<ProductCart> GetAll()
        {
            return _productCartRepository.GetAll();
        }

        public ProductCartComplexResult Search(ProductCart sm, out int recordCount)
        {
            return _productCartRepository.Search(sm, out recordCount);
        }
    }
}
