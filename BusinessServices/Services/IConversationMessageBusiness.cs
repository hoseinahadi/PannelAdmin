using DomainModel.Assist;
using DomainModel.DTO.Address;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Services
{
    public interface IConversationMessageBusiness
    {
        OperationResult Add(ConversationMessage model);
        OperationResult Update(ConversationMessage model);
        OperationResult Delete(int id);
        ConversationMessage Get(int id);
        List<ConversationMessage> GetAll();
        
    }
}
