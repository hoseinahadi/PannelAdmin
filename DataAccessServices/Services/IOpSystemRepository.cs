using DataAccessServices.Services.Base;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IOpSystemRepository:IBaseRepository<OpSystem,int>
    {
        bool HasOpSystem(string name);
    }
}
