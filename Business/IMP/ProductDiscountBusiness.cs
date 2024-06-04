using System.Collections.Generic;
using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProductDiscount;
using DomainModel.Models;

namespace Business.IMP
{
    public class ProductDiscountBusiness:IProductDiscountBusiness
    {
        private readonly IProductDiscountRepository _productDiscountRepository;

        public ProductDiscountBusiness(IProductDiscountRepository productDiscountRepository)
        {
            _productDiscountRepository = productDiscountRepository;
        }
        public OperationResult Add(ProductDiscount model)
        {
            return _productDiscountRepository.Add(model);
        }

        public OperationResult Update(ProductDiscount model)
        {
            return _productDiscountRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _productDiscountRepository.Delete(id);
        }

        public ProductDiscount Get(int id)
        {
            return _productDiscountRepository.Get(id);
        }

        public List<ProductDiscount> GetAll()
        {
            return _productDiscountRepository.GetAll();
        }

        public ProductDiscountComplexResult Search(ProductDiscount sm, out int recordCount)
        {
            return _productDiscountRepository.Search(sm, out recordCount);
        }
    }
}
