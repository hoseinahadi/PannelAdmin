using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.UserMessage;
using DomainModel.Models;

namespace Business.IMP
{
    public class UserMessageBusiness:IUserMessageBusiness
    {
        private readonly IUserMessageRepository _messageRepository;

        public UserMessageBusiness(IUserMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public OperationResult Add(UserMessage model)
        {
            return _messageRepository.Add(model);
        }

        public OperationResult Update(UserMessage model)
        {
            return _messageRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _messageRepository.Delete(id);
        }

        public UserMessage Get(int id)
        {
            return _messageRepository.Get(id);
        }

        public List<UserMessage> GetAll()
        {
            return _messageRepository.GetAll();
        }

        public UserMessageComplexResult Search(UserMessage sm, out int recordCount)
        {
            return _messageRepository.Search(sm, out recordCount);
        }
    }
}
