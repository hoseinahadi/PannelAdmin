using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.CategoryDiscount;
using DomainModel.DTO.OrderProduct;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CategoryDiscountRepository:ICategoryDiscountRepository
    {
        private readonly ShikaShopContext db;

        public CategoryDiscountRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(CategoryDiscount model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.CategoryDiscounts.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.CategoryDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.CategoryDiscountId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete",id);
            try
            {
                var result = db.CategoryDiscounts.FirstOrDefault(x=>x.CategoryDiscountId==id);
                if (result==null)
                {
                    return op.Failed("this is not found", id);
                }
                db.CategoryDiscounts.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success",id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(CategoryDiscount model)
        {
            OperationResult op = new OperationResult("Update", model.CategoryDiscountId);
            try
            {
                db.CategoryDiscounts.Attach(model);
                db.Entry<CategoryDiscount>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.CategoryDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.CategoryDiscountId);
            }
        }

        public CategoryDiscount Get(int id)
        {
            return db.CategoryDiscounts.FirstOrDefault(x => x.CategoryDiscountId == id);
        }

        public List<CategoryDiscount> GetAll()
        {
            return db.CategoryDiscounts.ToList();
        }

        public CategoryDiscountComplexResult Search(CategoryDiscount sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.CategoryDiscounts
                    select new CategoryDiscount
                    {
                        CategoryDiscountId = item.CategoryDiscountId,
                        CategoryId = item.CategoryId,
                        DiscountId = item.DiscountId,
                    };
                if (sm.CategoryId!=0)
                {
                    results = results.Where(x => x.CategoryId == sm.CategoryId);
                }
                if (sm.DiscountId != 0)
                {
                    results = results.Where(x => x.DiscountId == sm.DiscountId);
                }

                recordCount = results.Count();
                return new CategoryDiscountComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new CategoryDiscountComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
