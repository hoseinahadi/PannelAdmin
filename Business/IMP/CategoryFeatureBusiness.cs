using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.CategoryFeature;
using DomainModel.Models;

namespace Business.IMP
{
    public class CategoryFeatureBusiness:ICategoryFeatureBusiness
    {
        private readonly ICategoryFeatureRepository _categoryFeatureRepository;

        public CategoryFeatureBusiness(ICategoryFeatureRepository categoryFeatureRepository)
        {
            _categoryFeatureRepository = categoryFeatureRepository;
        }
        public OperationResult Add(CategoryFeature model)
        {
            return _categoryFeatureRepository.Add(model);
        }

        public OperationResult Update(CategoryFeature model)
        {
            return _categoryFeatureRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _categoryFeatureRepository.Delete(id);
        }

        public CategoryFeature Get(int id)
        {
            return _categoryFeatureRepository.Get(id);
        }

        public List<CategoryFeature> GetAll()
        {
            return _categoryFeatureRepository.GetAll();
        }

        public CategoryFeatureComplexResult Search(CategoryFeature sm, out int recordCount)
        {
            return _categoryFeatureRepository.Search(sm, out recordCount);
        }
    }
}
