using DomainModel.Assist;
using DomainModel.DTO.User;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IUserBusiness
    {
        OperationResult Add(UserAddEditModel model);
        OperationResult Update(UserAddEditModel model);
        OperationResult Delete(int id);
        User Get(int id);
        List<User> GetAll();
        UserComplexResults Search(UserSearchModel sm, out int recordCount);
        User GetUserByUserName(string userName);
        List<User> GetUserBuRole(string RoleName);
    }
}
