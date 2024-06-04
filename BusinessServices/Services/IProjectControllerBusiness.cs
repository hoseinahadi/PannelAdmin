using DomainModel.Assist;
using DomainModel.DTO.ProjectController;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IProjectControllerBusiness
    {
        OperationResult Delete(int id);
        OperationResult Update(ProjectControllerAddEditModel current);
        OperationResult AddNew(ProjectControllerAddEditModel current);
        ProjectControllerAddEditModel Get(int id);
        List<ProjectController> GetAll();
    }
}
