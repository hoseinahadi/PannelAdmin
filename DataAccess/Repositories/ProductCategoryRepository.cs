using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;

using DomainModel.Assist;
using DomainModel.DTO.ProductCategory;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductCategoryRepository:IProductCategoryRepository
    {
        private readonly ShikaShopContext db;

        public ProductCategoryRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ProductCategory model)
        {
            OperationResult op = new OperationResult("AddNew", model.ProductCategoryId);
            try
            {
                db.ProductCategories.Add(model);
                db.SaveChanges();
                return op.Succeed("Success",model.ProductCategoryId);

            }
            catch (Exception ex)
            {
                return op.Failed("Add ProductCategory Failed in repository =" + ex.Message, model.ProductCategoryId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.ProductCategories.FirstOrDefault(x => x.ProductCategoryId == id);
                if (result != null)
                {
                    db.ProductCategories.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete ProductCategories Succeed", id);
                }

                return op.Failed("this ProductCategories not found", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete ProductCategories failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(ProductCategory model)
        {
            OperationResult op = new OperationResult("Update", model.ProductCategoryId);
            try
            {
                db.ProductCategories.Attach(model);
                db.Entry<ProductCategory>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Success", model.ProductCategoryId);

            }
            catch (Exception ex)
            {
                return op.Failed("Update ProductCategory Failed in repository =" + ex.Message, model.ProductCategoryId);
            }
        }

        public ProductCategory Get(int id)
        {
            return db.ProductCategories.FirstOrDefault(x => x.ProductCategoryId==id);
        }

        public List<ProductCategory> GetAll()
        {
            return db.ProductCategories.ToList();
        }

        public ProductCategoryComplexResult Search(ProductCategory sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.ProductCategories
                    select new ProductCategory
                    {
                        CategoryId = item.CategoryId,
                        ProductCategoryId = item.ProductCategoryId,
                        ProductId = item.ProductId,
                    };
                if (sm.CategoryId != 0)
                {
                    results = results.Where(x => x.CategoryId == sm.CategoryId);
                }
                if (sm.ProductId != 0)
                {
                    results = results.Where(x => x.ProductId == sm.ProductId);
                }

                recordCount = results.Count();
                return new ProductCategoryComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new ProductCategoryComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
