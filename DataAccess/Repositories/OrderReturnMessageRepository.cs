using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OrderReturnMessage;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderReturnMessageRepository:IOrderReturnMessageRepository
    {
        private readonly ShikaShopContext db;

        public OrderReturnMessageRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(OrderReturnMessage model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.OrderReturnMessages.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.OrderReturnMessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.OrderReturnMessageId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.OrderReturnMessages.FirstOrDefault(x => x.OrderReturnMessageId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.OrderReturnMessages.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(OrderReturnMessage model)
        {
            OperationResult op = new OperationResult("Update", model.OrderReturnMessageId);
            try
            {
                db.OrderReturnMessages.Attach(model);
                db.Entry<OrderReturnMessage>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.OrderReturnMessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.OrderReturnMessageId);
            }
        }

        public OrderReturnMessage Get(int id)
        {
            return db.OrderReturnMessages.FirstOrDefault(x => x.OrderReturnMessageId == id);
        }

        public List<OrderReturnMessage> GetAll()
        {
            return db.OrderReturnMessages.ToList();
        }

        public OrderReturnMessageComplexResult Search(OrderReturnMessage sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.OrderReturnMessages
                    select new OrderReturnMessage
                    {
                        OrderReturnId = item.OrderReturnId,
                        MessageId = item.MessageId,
                        OrderReturnMessageId = item.OrderReturnMessageId,
                    };
                if (sm.OrderReturnId != 0)
                {
                    results = results.Where(x => x.OrderReturnId == sm.OrderReturnId);
                }
                if (sm.MessageId != 0)
                {
                    results = results.Where(x => x.MessageId == sm.MessageId);
                }

                recordCount = results.Count();
                return new OrderReturnMessageComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new OrderReturnMessageComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
