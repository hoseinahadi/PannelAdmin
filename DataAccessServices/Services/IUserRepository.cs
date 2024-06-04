using DataAccessServices.Services.Base;
using DomainModel.DTO.User;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IUserRepository:IBaseRepositorySearchable<User,int,UserSearchModel,UserComplexResults>
    {
        bool HasDuplicateUserName (string userName);
        User GetUserByUserName (string userName);
        List<User> GetUserBuRole(string RoleName);
        
    }
}
