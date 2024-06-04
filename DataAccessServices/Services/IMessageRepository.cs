using DataAccessServices.Services.Base;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IMessageRepository:IBaseRepository<Message,int>
    {
    }
}
