using BusinessServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.Models;

namespace Business.IMP
{
    
    public class ConversationMessageBusiness: IConversationMessageBusiness
    {
        private readonly IConversationMessageRepository _repository;

        public ConversationMessageBusiness(IConversationMessageRepository repository)
        {
            _repository = repository;
        }
        public OperationResult Add(ConversationMessage model)
        {
            return _repository.Add(model);
        }

        public OperationResult Update(ConversationMessage model)
        {
            return _repository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _repository.Delete(id);
        }

        public ConversationMessage Get(int id)
        {
            return _repository.Get(id);
        }

        public List<ConversationMessage> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
