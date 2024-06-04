using DomainModel.Assist;
using DomainModel.DTO.OpSystem;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IOpSystemBusiness
    {
        OperationResult Add(OpSystemAddEditModel model);
        OperationResult Update(OpSystemAddEditModel model);
        OperationResult Delete(int id);
        OpSystemAddEditModel Get(int id);
        List<OpSystem> GetAll();

    }
}
