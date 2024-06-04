using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;

using DomainModel.Assist;
using DomainModel.DTO.Feature;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class FeatureRepository:IFeatureRepository
    {
        private readonly ShikaShopContext db;

        public FeatureRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Feature model)
        {
            OperationResult op = new OperationResult("Add New Feature");
            try
            {
                if (HasFeatureName(model.FeatureName))
                {
                    return op.Failed("this feature Name exist ", model.FeatureId);
                }
                db.Features.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New feature succeed", model.FeatureId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Feature in repository =" + ex.Message, model.FeatureId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Feature", id);
            try
            {
                var result = db.Features.FirstOrDefault(x => x.FeatureId == id);

                if (result != null)
                {
                    db.Features.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete Feature succeed", id);
                }

                return op.Failed("This Feature not Exist", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Feature failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Feature model)
        {
            OperationResult op = new OperationResult("Update feature ", model.FeatureId);
            try
            {
                db.Features.Attach(model);
                db.Entry<Feature>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Feature Succeed",model.FeatureId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update feature failed in repository =" + ex.Message, model.FeatureId);
            }
        }

        public Feature Get(int id)
        {
            var result = db.Features.FirstOrDefault(x => x.FeatureId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<Feature> GetAll()
        {
            return db.Features.ToList();
        }

        public FeatureComplexResults Search(FeatureSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Features
                    select new FeatureSearchResult
                    {
                        FeatureId = item.FeatureId,
                        FeatureDescription = item.FeatureDescription,
                        FeatureName = item.FeatureName
                    };
                if (!string.IsNullOrEmpty(sm.FeatureName))
                {
                    results = results.Where(x => x.FeatureName.StartsWith(sm.FeatureName));
                }
                recordCount = results.Count();
                return new FeatureComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new FeatureComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }

        public bool HasFeatureName(string name)
        {
            return db.Features.Any(x => x.FeatureName == name);
        }
    }
}
