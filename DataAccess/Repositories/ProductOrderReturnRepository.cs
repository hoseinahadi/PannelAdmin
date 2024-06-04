
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProductOrderReturn;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductOrderReturnRepository: IProductOrderReturnRepository
    {
        private readonly ShikaShopContext db;

        public ProductOrderReturnRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ProductOrderReturn model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.ProductOrderReturns.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.ProductOrderReturnId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.ProductOrderReturnId);
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

        public OperationResult Update(ProductOrderReturn model)
        {
            OperationResult op = new OperationResult("Update", model.ProductOrderReturnId);
            try
            {
                db.ProductOrderReturns.Attach(model);
                db.Entry<ProductOrderReturn>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.ProductOrderReturnId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.ProductOrderReturnId);
            }
        }

        public ProductOrderReturn Get(int id)
        {
            return db.ProductOrderReturns.FirstOrDefault(x => x.ProductOrderReturnId == id);
        }

        public List<ProductOrderReturn> GetAll()
        {
            return db.ProductOrderReturns.ToList();
        }

        public ProductOrderReturnComplexResult Search(ProductOrderReturn sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.ProductOrderReturns
                    select new ProductOrderReturn
                    {
                        ProductOrderReturnId = item.ProductOrderReturnId,
                        OrderReturnId = item.OrderReturnId,
                        ProductId = item.ProductId,
                    };
                if (sm.OrderReturnId != 0)
                {
                    results = results.Where(x => x.OrderReturnId == sm.OrderReturnId);
                }
                if (sm.ProductId != 0)
                {
                    results = results.Where(x => x.ProductId == sm.ProductId);
                }

                recordCount = results.Count();
                return new ProductOrderReturnComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new ProductOrderReturnComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
