using DomainModel.Assist;
using DomainModel.DTO.UserFavorite;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IUserFavoriteBusiness
    {
        OperationResult Add(UserFavorite model);
        OperationResult Update(UserFavorite model);
        OperationResult Delete(int id);
        UserFavorite Get(int id);
        List<UserFavorite> GetAll();
        UserFavoriteComplexResult Search(UserFavorite sm, out int recordCount);

    }
}
