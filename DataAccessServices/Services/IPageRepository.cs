using DataAccessServices.Services.Base;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IPageRepository:IBaseRepository<Page,int>
    {
        bool HasPage(string name);
    }
}
