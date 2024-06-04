using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Discount;
using DomainModel.DTO.Feature;
using DomainModel.Models;

namespace Business.IMP
{
    public class FeatureBusiness:IFeatureBusiness
    {
        private readonly IFeatureRepository repo;

        public FeatureBusiness(IFeatureRepository repo)
        {
            this.repo = repo;
        }
        private Feature ToModel(FeatureAddEditModel addOrEdit)
        {
            return new Feature
            {
                FeatureDescription = addOrEdit.FeatureDescription,
                FeatureId = addOrEdit.FeatureId,
                FeatureName = addOrEdit.FeatureName,

                
            };
        }
        private FeatureAddEditModel ToAddEditModel(Feature model)
        {
            return new FeatureAddEditModel
            {
                FeatureDescription = model.FeatureDescription,
                FeatureId = model.FeatureId,
                FeatureName = model.FeatureName,

                
            };
        }
        public OperationResult Add(FeatureAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(FeatureAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public FeatureAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Feature> GetAll()
        {
            return repo.GetAll();
        }

        public FeatureComplexResults Search(FeatureSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
