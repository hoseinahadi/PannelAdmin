using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProductFeature;
using DomainModel.Models;

namespace Business.IMP
{
    public class ProductFeatureBusiness:IProductFeatureBusiness
    {
        private readonly IProductFeatureRepository _productFeatureRepository;

        public ProductFeatureBusiness(IProductFeatureRepository productFeatureRepository)
        {
            _productFeatureRepository = productFeatureRepository;
        }
        public OperationResult Add(ProductFeature model)
        {
            return _productFeatureRepository.Add(model);
        }

        public OperationResult Update(ProductFeature model)
        {
            return _productFeatureRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _productFeatureRepository.Delete(id);
        }

        public ProductFeature Get(int id)
        {
            return _productFeatureRepository.Get(id);
        }

        public List<ProductFeature> GetAll()
        {
            return _productFeatureRepository.GetAll();
        }

        public ProductFeatureComplexResult Search(ProductFeature sm, out int recordCount)
        {
            return _productFeatureRepository.Search(sm, out recordCount);
        }
    }
}
