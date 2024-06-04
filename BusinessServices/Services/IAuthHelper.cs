using DomainModel.DTO.User;

namespace BusinessServices.Services
{
    public interface IAuthHelper
    {
        void Signin(UserInfo account);
        void SignOut();
        UserInfo GetCurrentUserInfo();
    }
}