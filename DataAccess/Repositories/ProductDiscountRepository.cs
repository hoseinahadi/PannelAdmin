
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProductDiscount;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductDiscountRepository: IProductDiscountRepository
    {
        private readonly ShikaShopContext db;

        public ProductDiscountRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ProductDiscount model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.ProductDiscounts.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.ProductDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.ProductDiscountId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.ProductDiscounts.FirstOrDefault(x => x.ProductDiscountId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.ProductDiscounts.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(ProductDiscount model)
        {
            OperationResult op = new OperationResult("Update", model.ProductDiscountId);
            try
            {
                db.ProductDiscounts.Attach(model);
                db.Entry<ProductDiscount>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.ProductDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.ProductDiscountId);
            }
        }

        public ProductDiscount Get(int id)
        {
            return db.ProductDiscounts.FirstOrDefault(x => x.ProductDiscountId == id);
        }

        public List<ProductDiscount> GetAll()
        {
            return db.ProductDiscounts.ToList();
        }

        public ProductDiscountComplexResult Search(ProductDiscount sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.ProductDiscounts
                    select new ProductDiscount
                    {
                        DiscountId = item.DiscountId,
                        ProductDiscountId = item.ProductDiscountId,
                        ProductId = item.ProductId,
                    };
                if (sm.DiscountId != 0)
                {
                    results = results.Where(x => x.DiscountId == sm.DiscountId);
                }
                if (sm.ProductId != 0)
                {
                    results = results.Where(x => x.ProductId == sm.ProductId);
                }

                recordCount = results.Count();
                return new ProductDiscountComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new ProductDiscountComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
