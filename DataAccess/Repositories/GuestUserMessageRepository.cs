
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.GuestUserMessage;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class GuestUserMessageRepository: IGuestUserMessageRepository
    {
        private readonly ShikaShopContext db;

        public GuestUserMessageRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(GuestUserMessage model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.GuestUserMessages.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.GuestUserMessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.GuestUserMessageId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.GuestUserMessages.FirstOrDefault(x => x.GuestUserMessageId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.GuestUserMessages.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(GuestUserMessage model)
        {
            OperationResult op = new OperationResult("Update", model.GuestUserMessageId);
            try
            {
                db.GuestUserMessages.Attach(model);
                db.Entry<GuestUserMessage>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.GuestUserMessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.GuestUserMessageId);
            }
        }

        public GuestUserMessage Get(int id)
        {
            return db.GuestUserMessages.FirstOrDefault(x => x.GuestUserMessageId == id);
        }

        public List<GuestUserMessage> GetAll()
        {
            return db.GuestUserMessages.ToList();
        }

        public GuestUserMessageComplexResult Search(GuestUserMessage sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.GuestUserMessages
                    select new GuestUserMessage
                    {
                        MessageId = item.MessageId,
                        GuestUserId = item.GuestUserId,
                        GuestUserMessageId = item.MessageId,
                    };
                if (sm.MessageId != 0)
                {
                    results = results.Where(x => x.MessageId == sm.MessageId);
                }
                if (sm.GuestUserId != 0)
                {
                    results = results.Where(x => x.GuestUserId == sm.GuestUserId);
                }

                recordCount = results.Count();
                return new GuestUserMessageComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new GuestUserMessageComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
