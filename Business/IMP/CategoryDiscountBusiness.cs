using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.CategoryDiscount;
using DomainModel.Models;

namespace Business.IMP
{
    public class CategoryDiscountBusiness:ICategoryDiscountBusiness
    {
        private readonly ICategoryDiscountRepository _categoryDiscountRepository;

        public CategoryDiscountBusiness(ICategoryDiscountRepository categoryDiscountRepository)
        {
            _categoryDiscountRepository = categoryDiscountRepository;
        }
        public OperationResult Add(CategoryDiscount model)
        {
            return _categoryDiscountRepository.Add(model);
        }

        public OperationResult Update(CategoryDiscount model)
        {
            return _categoryDiscountRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _categoryDiscountRepository.Delete(id);
        }

        public CategoryDiscount Get(int id)
        {
            return _categoryDiscountRepository.Get(id);
        }

        public List<CategoryDiscount> GetAll()
        {
            return _categoryDiscountRepository.GetAll();
        }

        public CategoryDiscountComplexResult Search(CategoryDiscount sm, out int recordCount)
        {
            return _categoryDiscountRepository.Search(sm, out recordCount);
        }
    }
}
