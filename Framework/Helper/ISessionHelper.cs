
using DomainModel.DTO.User;


namespace Framework.Helper
{
   public interface ISessionHelper
   {
       void AddCurrentUserToSession(CurrentUser user);
       void RemoveCurrenrtFromSession(string Key);
       CurrentUser GetCurrentUser();

   }
}
