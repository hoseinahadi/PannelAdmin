using DataAccessServices.Services.Base;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IGenderRepository:IBaseRepository<Gender,int>
    {
        bool HasGenderName(string name);
    }
}
