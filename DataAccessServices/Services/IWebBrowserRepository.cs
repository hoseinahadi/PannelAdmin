using DataAccessServices.Services.Base;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IWebBrowserRepository:IBaseRepository<WebBrowser,int>
    {
        bool HasName(string name);
    }
}
