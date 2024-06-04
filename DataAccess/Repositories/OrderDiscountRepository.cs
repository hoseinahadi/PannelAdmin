using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OrderDiscount;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderDiscountRepository:IOrderDiscountRepository
    {
        private readonly ShikaShopContext db;

        public OrderDiscountRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(OrderDiscount model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.OrderDiscounts.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.OrderDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.OrderDiscountId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.OrderDiscounts.FirstOrDefault(x => x.OrderDiscountId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.OrderDiscounts.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(OrderDiscount model)
        {
            OperationResult op = new OperationResult("Update", model.OrderDiscountId);
            try
            {
                db.OrderDiscounts.Attach(model);
                db.Entry<OrderDiscount>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.OrderDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.OrderDiscountId);
            }
        }

        public OrderDiscount Get(int id)
        {
            return db.OrderDiscounts.FirstOrDefault(x => x.OrderDiscountId == id);
        }

        public List<OrderDiscount> GetAll()
        {
            return db.OrderDiscounts.ToList();
        }

        public OrderDiscountComplexResult Search(OrderDiscount sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.OrderDiscounts
                    select new OrderDiscount
                    {
                        OrderDiscountId = item.OrderDiscountId,
                        OrderId = item.OrderId,
                        DiscountId = item.DiscountId,
                    };
                if (sm.OrderId != 0)
                {
                    results = results.Where(x => x.OrderId == sm.OrderId);
                }
                if (sm.DiscountId != 0)
                {
                    results = results.Where(x => x.DiscountId == sm.DiscountId);
                }

                recordCount = results.Count();
                return new OrderDiscountComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new OrderDiscountComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
