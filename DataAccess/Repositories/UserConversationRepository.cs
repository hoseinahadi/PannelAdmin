
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
    public class UserConversationRepository : IUserConversationRepository
    {
        private readonly ShikaShopContext db;

        public UserConversationRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(UserConversation model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.UserConversations.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.UserConversationId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.UserConversationId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.UserConversations.FirstOrDefault(x => x.UserConversationId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.UserConversations.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(UserConversation model)
        {
            OperationResult op = new OperationResult("Update", model.UserConversationId);
            try
            {
                db.UserConversations.Attach(model);
                db.Entry<UserConversation>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.UserConversationId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.UserConversationId);
            }
        }

        public UserConversation Get(int id)
        {
            return db.UserConversations.FirstOrDefault(x => x.UserConversationId == id);
        }

        public List<UserConversation> GetAll()
        {
            return db.UserConversations.ToList();
        }

       
    }
}
