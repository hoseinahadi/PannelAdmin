using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Order;
using DomainModel.DTO.OrderReturn;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderReturnRepository:IOrderReturnRepository
    {
        private readonly ShikaShopContext db;

        public OrderReturnRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(OrderReturn model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                db.OrderReturns.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Order Return Succeed", model.OrderReturnId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Order Return failed in repository =" + ex.Message, model.OrderId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.OrderReturns.FirstOrDefault(x => x.OrderReturnId == id);
                if (result != null)
                {
                    db.OrderReturns.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete Order Return succeed", id);
                }

                return op.Failed("this order Return not found", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Order Return failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(OrderReturn model)
        {
            OperationResult op = new OperationResult("Update", model.OrderReturnId);
            try
            {
                db.OrderReturns.Attach(model);
                db.Entry<OrderReturn>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Order Return succeed", model.OrderReturnId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Order Return failed in repository =" + ex.Message, model.OrderReturnId);
            }
        }

        public OrderReturn Get(int id)
        {
            var result = db.OrderReturns.FirstOrDefault(x => x.OrderReturnId == id);
            if (result!=null)
            {
                return result;
            }

            return null;
        }

        public List<OrderReturn> GetAll()
        {
            return db.OrderReturns.ToList();
        }

        public OrderReturnComplexResults Search(OrderReturnSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.OrderReturns
                              select new OrderReturnSearchResult
                              {
                                  EmployeeId = item.EmployeeId,
                                  AddressId = item.AddressId,
                                  CurrencyId = item.CurrencyId,
                                  OrderId = item.OrderId,
                                  State = item.State,
                                  AddDate = item.AddDate,
                                  OrderReturnId = item.OrderReturnId,
                                  Question = item.Question,

                              };
                if (!string.IsNullOrEmpty(sm.State))
                {
                    results = results.Where(x => x.State.StartsWith(sm.State));
                }
                if (!string.IsNullOrEmpty(sm.Question))
                {
                    results = results.Where(x => x.Question.StartsWith(sm.Question));
                }
                if (sm.AddDate!=null)
                {
                    results = results.Where(x => x.AddDate==sm.AddDate);
                }




                recordCount = results.Count();
                return new OrderReturnComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new OrderReturnComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
