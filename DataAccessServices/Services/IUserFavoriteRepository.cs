using DataAccessServices.Services.Base;
using DomainModel.DTO.UserFavorite;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface IUserFavoriteRepository : IBaseRepositorySearchable<UserFavorite,int, UserFavorite, UserFavoriteComplexResult>
    {
        
    }
}
