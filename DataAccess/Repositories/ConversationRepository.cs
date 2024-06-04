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
    public class ConversationRepository : IConversationRepository
    {
        private readonly ShikaShopContext db;

        public ConversationRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Conversation model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {

                db.Conversations.Add(model);
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
                var result = db.Conversations.FirstOrDefault(x => x.ConversationId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }

                db.SaveChanges();

                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(Conversation model)
        {
            OperationResult op = new OperationResult("Update", model.ConversationId);
            try
            {

                db.Conversations.Attach(model);
                db.Entry<Conversation>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.ConversationId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.ConversationId);
            }
        }

        public Conversation Get(int id)
        {
            return db.Conversations.FirstOrDefault(x => x.ConversationId == id);
        }

        public List<Conversation> GetAll()
        {
            return db.Conversations.ToList();
        }


        public List<UserConversation> GetUserConversation(int id)
        {



            var results = from item in db.UserConversations
                          select new UserConversation
                          {
                              ConversationId = item.ConversationId,
                              UserConversationId = item.UserConversationId,
                              UserId = item.UserId
                          };

            if (id != null)
            {
                results = results.Where(x => x.ConversationId == id);
            }

            return results.ToList();



        }

        public List<ConversationMessage> GetUserConversationMessage(int id)
        {
            var results = from item in db.ConversationMessages
                          select new ConversationMessage
                {
                    ConversationId = item.ConversationId,
                    MessageId = item.MessageId,
                    ConversationMessageId = item.ConversationMessageId
                };

            if (id != null)
            {
                results = results.Where(x => x.ConversationId == id);
            }

            return results.ToList();
        }
    }
}