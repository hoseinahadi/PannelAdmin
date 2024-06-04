using DomainModel.Assist;
using DomainModel.DTO.Message;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IMessageBusiness
    {
        OperationResult Add(MessageAddEditModel model);
        OperationResult Update(MessageAddEditModel model);
        OperationResult Delete(int id);
        Message Get(int id);
        List<Message> GetAll();
    }
}
