using DomainModel.Assist;
using DomainModel.DTO.GuestUserMessage;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IGuestUserMessageBusiness
    {
        OperationResult Add(GuestUserMessage model);
        OperationResult Update(GuestUserMessage model);
        OperationResult Delete(int id);
        GuestUserMessage Get(int id);
        List<GuestUserMessage> GetAll();
        GuestUserMessageComplexResult Search(GuestUserMessage sm, out int recordCount);

    }
}
