using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OrderMessage;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderMessageRepository:IOrderMessageRepository
    {
        private readonly ShikaShopContext db;

        public OrderMessageRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(OrderMessage model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.OrderMessages.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.OrderMessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.OrderMessageId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.OrderMessages.FirstOrDefault(x => x.OrderMessageId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.OrderMessages.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(OrderMessage model)
        {
            OperationResult op = new OperationResult("Update", model.OrderMessageId);
            try
            {
                db.OrderMessages.Attach(model);
                db.Entry<OrderMessage>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.OrderMessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.OrderMessageId);
            }
        }

        public OrderMessage Get(int id)
        {
            return db.OrderMessages.FirstOrDefault(x => x.OrderMessageId == id);
        }

        public List<OrderMessage> GetAll()
        {
            return db.OrderMessages.ToList();
        }

        public OrderMessageComplexResult Search(OrderMessage sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.OrderMessages
                    select new OrderMessage
                    {
                        OrderId = item.OrderId,
                        OrderMessageId = item.OrderMessageId,
                        MessageId = item.MessageId,
                    };
                if (sm.OrderId != 0)
                {
                    results = results.Where(x => x.OrderId == sm.OrderId);
                }
                if (sm.MessageId != 0)
                {
                    results = results.Where(x => x.MessageId == sm.MessageId);
                }

                recordCount = results.Count();
                return new OrderMessageComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new OrderMessageComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
