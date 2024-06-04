using DomainModel.Assist;
using DomainModel.DTO.Gender;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IGenderBusiness
    {
        OperationResult Add(GenderAddEditModel model);
        OperationResult Update(GenderAddEditModel model);
        OperationResult Delete(int id);
        GenderAddEditModel Get(int id);
        List<Gender> GetAll();

    }
}
