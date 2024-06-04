using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.ContactUs;
using DomainModel.DTO.Conversation;
using DomainModel.DTO.ProductDiscount;
using DomainModel.Models;

namespace Business.IMP
{
    public class ConversationBusiness : IConversationBusiness
    {
        private Conversation ToModel(ConversationAddEditModel addOrEdit)
        {
            return new Conversation
            {
                Status = addOrEdit.Status,
                ConversationId = addOrEdit.ConversationId,
                isAccept = addOrEdit.isAccept
            };
        }
        private ConversationAddEditModel ToAddEditModel(Conversation model)
        {
            return new ConversationAddEditModel
            {
                Status = model.Status,
                ConversationId = model.ConversationId,
                isAccept = model.isAccept
            };
        }
        private readonly IConversationRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IConversationMessageRepository _conversationMessageRepository;
        private readonly IUserConversationRepository _userConversationRepository;


        public ConversationBusiness(IConversationRepository repository, IUserRepository userRepository, IMessageRepository messageRepository, IConversationMessageRepository conversationMessageRepository, IUserConversationRepository userConversationRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _conversationMessageRepository = conversationMessageRepository;
            _userConversationRepository = userConversationRepository;
        }
        public OperationResult Add(ConversationAddEditModel model)
        {
            
            
            var x =  _repository.Add(ToModel(model));
            var user = _userRepository.Get(model.UserId);
            var message = _messageRepository.Get(model.MessageId);
            var conve = _repository.Get(x.RecordId);
            var convmessage = new ConversationMessage
            {
                MessageId = message.MessageId,
                ConversationId = x.RecordId,
                Message = message,
                Conversation = conve,
            };
            var Userconv = new UserConversation
            {
                UserId = user.UserId,
                ConversationId = x.RecordId,
                Conversation = conve,
                User = user
            };
            var cmAdd = _conversationMessageRepository.Add(convmessage);
            var cm = _conversationMessageRepository.Get(cmAdd.RecordId);
            var userconvadd = _userConversationRepository.Add(Userconv);
            var userconv = _userConversationRepository.Get(userconvadd.RecordId);
            List<ConversationMessage> listConversationMessage = new List<ConversationMessage>();
            listConversationMessage.Add(cm);
            List<UserConversation> listUserConversation = new List<UserConversation>();
            listUserConversation.Add(userconv);
            var co = new Conversation
            {
                Status = model.Status,
                ConversationId = conve.ConversationId,
                ConversationMessages = listConversationMessage,
                Users = listUserConversation,
                isAccept = true
            };
            var m = _repository.Update(co);
            return m;
        }

        public OperationResult Update(ConversationAddEditModel model)
        {
            return _repository.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Conversation Get(int id)
        {
            var conv= _repository.Get(id);
            return conv;
        }

        public List<Conversation> GetAll()
        {
            return _repository.GetAll();
        }

        public List<ConversationMessage> GetConversationMessage(int id)
        {
            return _repository.GetUserConversationMessage(id);
        }

        public List<UserConversation> GetUserConversation(int id)
        {
            return _repository.GetUserConversation(id);
        }

        public List<ConversationMessage> GetConversationWithMessageId(int messageid)
        {
            return _conversationMessageRepository.GetConversationWithMessageId(messageid);
        }
    }
}
