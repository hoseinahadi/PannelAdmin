using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ShikaShopContext db;

        public MessageRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Message model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                db.Messages.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New message succeed", model.MessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Message failed in repository =" + ex.Message, model.MessageId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete ", id);
            try
            {
                var result = db.Messages.FirstOrDefault(x => x.MessageId == id);
                if (result != null)
                {
                    db.Messages.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete message succeed", id);
                }

                return op.Failed("this message not found", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete message failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Message model)
        {
            OperationResult op = new OperationResult("Update");
            try
            {
                db.Messages.Attach(model);
                db.Entry<Message>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update message succeed", model.MessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update message failed in repository =" + ex.Message, model.MessageId);
            }
        }

        public Message Get(int id)
        {
            var result = db.Messages.FirstOrDefault(x => x.MessageId == id);

            if (result != null)
            {
                //result.Read = true;
                Update(result);
                return result;
            }
            return null;
        }

        public List<Message> GetAll()
        {
            return db.Messages.ToList();
        }
    }
}
