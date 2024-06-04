using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.CategoryFeature;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CategoryFeatureRepository:ICategoryFeatureRepository
    {
        private readonly ShikaShopContext db;

        public CategoryFeatureRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(CategoryFeature model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.CategoryFeatures.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.CategoryFeatureId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.CategoryFeatureId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.CategoryFeatures.FirstOrDefault(x => x.CategoryFeatureId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.CategoryFeatures.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(CategoryFeature model)
        {
            OperationResult op = new OperationResult("Update", model.CategoryFeatureId);
            try
            {
                db.CategoryFeatures.Attach(model);
                db.Entry<CategoryFeature>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.CategoryFeatureId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.CategoryFeatureId);
            }
        }

        public CategoryFeature Get(int id)
        {
            return db.CategoryFeatures.FirstOrDefault(x => x.CategoryFeatureId == id);
        }

        public List<CategoryFeature> GetAll()
        {
            return db.CategoryFeatures.ToList();
        }

        public CategoryFeatureComplexResult Search(CategoryFeature sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.CategoryFeatures
                              select new CategoryFeature
                    {
                        CategoryId = item.CategoryFeatureId,
                        CategoryFeatureId = item.CategoryFeatureId,
                        FeatureId = item.FeatureId,

                    };
                if (sm.CategoryId != 0)
                {
                    results = results.Where(x => x.CategoryId == sm.CategoryId);
                }
                if (sm.FeatureId != 0)
                {
                    results = results.Where(x => x.FeatureId == sm.FeatureId);
                }

                recordCount = results.Count();
                return new CategoryFeatureComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new CategoryFeatureComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
