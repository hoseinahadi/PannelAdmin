
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OrderProduct;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderProductRepository: IOrderProductRepository
    {
        private readonly ShikaShopContext db;

        public OrderProductRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(OrderProduct model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.OrderProducts.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.OrderProductId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.OrderProductId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.OrderProducts.FirstOrDefault(x => x.OrderProductId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.OrderProducts.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(OrderProduct model)
        {
            OperationResult op = new OperationResult("Update", model.OrderProductId);
            try
            {
                db.OrderProducts.Attach(model);
                db.Entry<OrderProduct>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.OrderProductId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.OrderProductId);
            }
        }

        public OrderProduct Get(int id)
        {
            return db.OrderProducts.FirstOrDefault(x => x.OrderProductId == id);
        }

        public List<OrderProduct> GetAll()
        {
            return db.OrderProducts.ToList();
        }

        public OrderProductComplexResult Search(OrderProduct sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.OrderProducts
                    select new OrderProduct
                    {
                        OrderProductId = item.OrderProductId,
                        ProductId = item.ProductId,
                        OrderId = item.OrderId,
                    };
                if (sm.ProductId != 0)
                {
                    results = results.Where(x => x.ProductId == sm.ProductId);
                }
                if (sm.OrderId != 0)
                {
                    results = results.Where(x => x.OrderId == sm.OrderId);
                }

                recordCount = results.Count();
                return new OrderProductComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new OrderProductComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
