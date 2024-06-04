using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Location;
using DomainModel.DTO.Message;
using DomainModel.Models;

namespace Business.IMP
{
    public class MessageBusiness : IMessageBusiness
    {
        private readonly IMessageRepository repo;
        
        public MessageBusiness(IMessageRepository repo)
        {
            this.repo = repo;
        }
        private Message ToModel(MessageAddEditModel addOrEdit)
        {
            return new Message
            {
                MessageBody = addOrEdit.MessageBody,
                MessageHeader = addOrEdit.MessageHeader,
                MessageId = addOrEdit.MessageId,
                Read = addOrEdit.Read


            };
        }
        private MessageAddEditModel ToAddEditModel(Message model)
        {
            return new MessageAddEditModel
            {
                MessageBody = model.MessageBody,
                MessageHeader = model.MessageHeader,
                MessageId = model.MessageId,
                Read = model.Read
            };
        }
        public OperationResult Add(MessageAddEditModel model)
        {

            return repo.Add(ToModel(model));
        }

        public OperationResult Update(MessageAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public Message Get(int id)
        {
            return repo.Get(id);
        }

        public List<Message> GetAll()
        {
            return repo.GetAll();
        }
    }
}
