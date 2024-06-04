
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProductCart;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductCartRepository: IProductCartRepository
    {
        private readonly ShikaShopContext db;

        public ProductCartRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ProductCart model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.ProductCarts.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.ProductCartId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.ProductCartId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.ProductCarts.FirstOrDefault(x => x.ProductCartId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.ProductCarts.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(ProductCart model)
        {
            OperationResult op = new OperationResult("Update", model.ProductCartId);
            try
            {
                db.ProductCarts.Attach(model);
                db.Entry<ProductCart>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.ProductCartId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.ProductCartId);
            }
        }

        public ProductCart Get(int id)
        {
            return db.ProductCarts.FirstOrDefault(x => x.ProductCartId == id);
        }

        public List<ProductCart> GetAll()
        {
            return db.ProductCarts.ToList();
        }

        public ProductCartComplexResult Search(ProductCart sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.ProductCarts
                    select new ProductCart
                    {
                        ProductCartId = item.ProductCartId,
                        CartId = item.CartId,
                        ProductId = item.ProductId,
                    };
                if (sm.CartId != 0)
                {
                    results = results.Where(x => x.CartId == sm.CartId);
                }
                if (sm.ProductId != 0)
                {
                    results = results.Where(x => x.ProductId == sm.ProductId);
                }

                recordCount = results.Count();
                return new ProductCartComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new ProductCartComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
