using DomainModel.Assist;
using DomainModel.DTO.User;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IAccountApplication
    {
        OperationResult Login(Login login);
        OperationResult Register(User command);
        void LogoutUser();
        UserInfo GetAccountInfo();
        bool CheckIfUserHasAccess(CheckPermission per);

    }
}
