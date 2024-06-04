using DomainModel.Assist;
using DomainModel.DTO.Location;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ILocationBusiness
    {
        OperationResult Add(LocationAddEditModel model);
        OperationResult Update(LocationAddEditModel model);
        OperationResult Delete(int id);
        LocationAddEditModel Get(int id);
        List<Location> GetAll();

    }
}
