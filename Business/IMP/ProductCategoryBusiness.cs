using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProductCategory;
using DomainModel.Models;

namespace Business.IMP
{
    public class ProductCategoryBusiness:IProductCategoryBusiness
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryBusiness(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public OperationResult Add(ProductCategory model)
        {
            return _productCategoryRepository.Add(model);
        }

        public OperationResult Update(ProductCategory model)
        {
            return _productCategoryRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public ProductCategory Get(int id)
        {
            return _productCategoryRepository.Get(id);
        }

        public List<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public ProductCategoryComplexResult Search(ProductCategory sm, out int recordCount)
        {
            return _productCategoryRepository.Search(sm, out recordCount);
        }
    }
}
