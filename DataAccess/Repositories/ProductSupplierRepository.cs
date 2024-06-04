
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ProductSupplier;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductSupplierRepository: IProductSupplierRepository
    {
        private readonly ShikaShopContext db;

        public ProductSupplierRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ProductSupplier model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.ProductSuppliers.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.ProductSupplierId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.ProductSupplierId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.ProductSuppliers.FirstOrDefault(x => x.ProductSupplierId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.ProductSuppliers.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(ProductSupplier model)
        {
            OperationResult op = new OperationResult("Update", model.ProductSupplierId);
            try
            {
                db.ProductSuppliers.Attach(model);
                db.Entry<ProductSupplier>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.ProductSupplierId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.ProductSupplierId);
            }
        }

        public ProductSupplier Get(int id)
        {
            return db.ProductSuppliers.FirstOrDefault(x => x.ProductSupplierId == id);
        }

        public List<ProductSupplier> GetAll()
        {
            return db.ProductSuppliers.ToList();
        }

        public ProductSupplierComplexResult Search(ProductSupplier sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.ProductSuppliers
                    select new ProductSupplier
                    {
                        ProductSupplierId = item.ProductSupplierId,
                        SupplierId = item.SupplierId,
                        ProductId = item.ProductId,
                    };
                if (sm.SupplierId != 0)
                {
                    results = results.Where(x => x.SupplierId == sm.SupplierId);
                }
                if (sm.ProductId != 0)
                {
                    results = results.Where(x => x.ProductId == sm.ProductId);
                }

                recordCount = results.Count();
                return new ProductSupplierComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new ProductSupplierComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
