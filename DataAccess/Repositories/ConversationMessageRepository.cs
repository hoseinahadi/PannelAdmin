
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
    public class ConversationMessageRepository : IConversationMessageRepository
    {
        private readonly ShikaShopContext db;

        public ConversationMessageRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ConversationMessage model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.ConversationMessages.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.ConversationId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.ConversationId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.ConversationMessages.FirstOrDefault(x => x.ConversationMessageId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.ConversationMessages.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(ConversationMessage model)
        {
            OperationResult op = new OperationResult("Update", model.ConversationId);
            try
            {
                db.ConversationMessages.Attach(model);
                db.Entry<ConversationMessage>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.ConversationId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.ConversationId);
            }
        }

        public ConversationMessage Get(int id)
        {
            return db.ConversationMessages.FirstOrDefault(x => x.ConversationMessageId == id);
        }

        public List<ConversationMessage> GetAll()
        {
            return db.ConversationMessages.ToList();
        }

        public List<ConversationMessage> GetConversationWithMessageId(int messageid)
        {
            
                var results = from item in db.ConversationMessages
                    select new ConversationMessage
                    {
                        ConversationId = item.ConversationId,
                        MessageId = item.MessageId,
                        ConversationMessageId = item.ConversationMessageId
                    };
                if (messageid != null)
                {
                    results = results.Where(x => x.MessageId == messageid);
                }

                return results.ToList();
            
            
        }
    }
}
