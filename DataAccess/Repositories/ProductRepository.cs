
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;

using DomainModel.Assist;
using DomainModel.DTO.Order;
using DomainModel.DTO.Product;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ShikaShopContext db;

        public ProductRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Product model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                if (HasProduct(model.ProductName))
                {
                    return op.Failed("this Product Exist", model.ProductId);
                }
                db.Products.Add(model);
                db.SaveChanges();
                return op.Succeed("Add Product succeed", model.ProductId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Product failed in repository =" + ex.Message, model.ProductId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.Products.FirstOrDefault(x => x.ProductId == id);
                if (result != null)
                {
                    db.Products.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete product succeed", id);
                }

                return op.Failed("this product not found",id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete product failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Product model)
        {
            OperationResult op = new OperationResult("Update", model.ProductId);
            try
            {
                db.Products.Attach(model);
                db.Entry<Product>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Product succeed", model.ProductId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Product failed in repository =" + ex.Message, model.ProductId);
            }
        }

        public Product Get(int id)
        {
            var result = db.Products.FirstOrDefault(x => x.ProductId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public ProductComplexResults Search(ProductSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Products
                              select new ProductSearchResult
                              {
                                  CurrencyId = item.CurrencyId,
                                  State = item.State,
                                  AddDate = item.AddDate,
                                  ByPrice = item.ByPrice,
                                  Description = item.Description,
                                  OnSale = item.OnSale,
                                  Price = item.Price,
                                  ProductId = item.ProductId,
                                  WholeSalePrice = item.WholeSalePrice,
                                  Quantity = item.Quantity,
                              };
                if (!string.IsNullOrEmpty(sm.State))
                {
                    results = results.Where(x => x.State.StartsWith(sm.State));
                }
                if (sm.AddDate!=null)
                {
                    results = results.Where(x => x.AddDate==sm.AddDate);
                }
                if (sm.ByPrice != null)
                {
                    results = results.Where(x => x.ByPrice == sm.ByPrice);
                }
                if (sm.OnSale != null)
                {
                    results = results.Where(x => x.OnSale == sm.OnSale);
                }
                if (sm.Price != null)
                {
                    results = results.Where(x => x.Price == sm.Price);
                }
                if (sm.WholeSalePrice != null)
                {
                    results = results.Where(x => x.WholeSalePrice == sm.WholeSalePrice);
                }





                recordCount = results.Count();
                return new ProductComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new ProductComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }

        public bool HasProduct(string name)
        {
            return db.Products.Any(x => x.ProductName == name);
        }
    }
}
