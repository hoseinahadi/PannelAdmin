using DomainModel.Assist;
using DomainModel.DTO.UserMessage;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IUserMessageBusiness
    {
        OperationResult Add(UserMessage model);
        OperationResult Update(UserMessage model);
        OperationResult Delete(int id);
        UserMessage Get(int id);
        List<UserMessage> GetAll();
        UserMessageComplexResult Search(UserMessage sm, out int recordCount);

    }
}
