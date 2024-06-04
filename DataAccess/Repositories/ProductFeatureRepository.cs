
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProductFeature;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductFeatureRepository: IProductFeatureRepository
    {
        private readonly ShikaShopContext db;

        public ProductFeatureRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ProductFeature model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.ProductFeatures.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.ProductFeatureId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.ProductFeatureId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.ProductFeatures.FirstOrDefault(x => x.ProductFeatureId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.ProductFeatures.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(ProductFeature model)
        {
            OperationResult op = new OperationResult("Update", model.ProductFeatureId);
            try
            {
                db.ProductFeatures.Attach(model);
                db.Entry<ProductFeature>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.ProductFeatureId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.ProductFeatureId);
            }
        }

        public ProductFeature Get(int id)
        {
            return db.ProductFeatures.FirstOrDefault(x => x.ProductFeatureId == id);
        }

        public List<ProductFeature> GetAll()
        {
            return db.ProductFeatures.ToList(); 
        }

        public ProductFeatureComplexResult Search(ProductFeature sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.ProductFeatures
                    select new ProductFeature
                    {
                        ProductFeatureId = item.ProductFeatureId,
                        FeatureId = item.FeatureId,
                        ProductId = item.ProductId,
                    };
                if (sm.FeatureId != 0)
                {
                    results = results.Where(x => x.FeatureId == sm.FeatureId);
                }
                if (sm.ProductId != 0)
                {
                    results = results.Where(x => x.ProductId == sm.ProductId);
                }

                recordCount = results.Count();
                return new ProductFeatureComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new ProductFeatureComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
