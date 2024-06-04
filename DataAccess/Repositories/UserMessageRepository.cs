
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.UserMessage;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserMessageRepository : IUserMessageRepository
    {
        private readonly ShikaShopContext db;

        public UserMessageRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(UserMessage model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.UserMessages.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.UserMessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.UserMessageId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.UserMessages.FirstOrDefault(x => x.UserMessageId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.UserMessages.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(UserMessage model)
        {
            OperationResult op = new OperationResult("Update", model.UserMessageId);
            try
            {
                db.UserMessages.Attach(model);
                db.Entry<UserMessage>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.UserMessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.UserMessageId);
            }
        }

        public UserMessage Get(int id)
        {
            return db.UserMessages.FirstOrDefault(x => x.UserMessageId == id);
        }

        public List<UserMessage> GetAll()
        {
            return db.UserMessages.ToList();
        }

        public UserMessageComplexResult Search(UserMessage sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.UserMessages
                    select new UserMessage
                    {
                        UserId = item.UserId,
                        MessageId = item.MessageId,
                        UserMessageId = item.UserId,
                    };
                if (sm.UserId != 0)
                {
                    results = results.Where(x => x.UserId == sm.UserId);
                }
                if (sm.MessageId != 0)
                {
                    results = results.Where(x => x.MessageId == sm.MessageId);
                }
                

                recordCount = results.Count();
                return new UserMessageComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new UserMessageComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
