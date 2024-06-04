using DomainModel.Assist;
using DomainModel.DTO.Role;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IRoleBusiness
    {
        OperationResult Delete(int id);
        OperationResult Update(RoleAddEditModel current);
        OperationResult AddNew(RoleAddEditModel current);
        RoleAddEditModel Get(int id);
        List<Role> GetAll();
        
    }
}
