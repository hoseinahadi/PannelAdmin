using DomainModel.Assist;
using DomainModel.DTO.ProjectAction;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IProjectActionBusiness
    {
        OperationResult Delete(int id);
        OperationResult Update(ProjectActionAddEditModel current);
        OperationResult AddNew(ProjectActionAddEditModel current);
        ProjectActionAddEditModel Get(int id);
        List<ProjectAction> GetAll();
    }
}
