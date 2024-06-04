using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.Configuration;
using DomainModel.DTO.Image;
using DomainModel.DTO.Order;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly ShikaShopContext db;

        public OrderRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Order model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                db.Orders.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Order Succeed", model.OrderId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Order failed in repository =" + ex.Message, model.OrderId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.Orders.FirstOrDefault(x => x.OrderId == id);
                if (result != null)
                {
                     db.Orders.Remove(result);
                     db.SaveChanges();
                     return op.Succeed("Delete Order Succeed", id);
                }

                return op.Failed("this order not found", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Order failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Order model)
        {
            OperationResult op = new OperationResult("Update", model.OrderId);
            try
            {
                db.Orders.Attach(model);
                db.Entry<Order>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Order Succeed", model.OrderId);

            }   
            catch (Exception ex)
            {
                return op.Failed("Update Order failed in repository =" + ex.Message, model.OrderId);
            }
        }

        public Order Get(int id)
        {
            var result = db.Orders.FirstOrDefault(x => x.OrderId == id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public List<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public OrderComplexResults Search(OrderSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Orders
                              select new OrderSearchResult
                              {
                                  UserId = item.UserId,
                                  EmployeeId = item.EmployeeId.Value,
                                  AddressId = item.AddressId,
                                  CurrencyId = item.CurrencyId,
                                  OrderId = item.OrderId,
                                  ProductCount = item.ProductCount,
                                  Payment = item.Payment,
                                  SecureKey = item.SecureKey,
                                  ShoppingPhone = item.ShoppingPhone,
                                  AddDate = item.AddDate
                                  
                              };
                
                if (!string.IsNullOrEmpty(sm.ShoppingPhone))
                {
                    results = results.Where(x => x.ShoppingPhone.StartsWith(sm.ShoppingPhone));
                }
                if (!string.IsNullOrEmpty(sm.SecureKey))
                {
                    results = results.Where(x => x.SecureKey.StartsWith(sm.SecureKey));
                }
                if (!string.IsNullOrEmpty(sm.ShoppingPhone))
                {
                    results = results.Where(x => x.ShoppingPhone.StartsWith(sm.ShoppingPhone));
                }
                if (sm.StartSearchDate!=null)
                {
                    results = results.Where(x => x.AddDate >= sm.StartSearchDate);
                }
                if (sm.EndSearchDate != null)
                {
                    results = results.Where(x => x.AddDate <= sm.EndSearchDate);
                }






                recordCount = results.Count();
                return new OrderComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new OrderComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
