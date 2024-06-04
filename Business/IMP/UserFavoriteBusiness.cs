using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.UserFavorite;
using DomainModel.Models;

namespace Business.IMP
{
    public class UserFavoriteBusiness:IUserFavoriteBusiness
    {
        private readonly IUserFavoriteRepository _userFavoriteRepository;

        public UserFavoriteBusiness(IUserFavoriteRepository userFavoriteRepository)
        {
            _userFavoriteRepository = userFavoriteRepository;
        }
        public OperationResult Add(UserFavorite model)
        {
            return _userFavoriteRepository.Add(model);
        }

        public OperationResult Update(UserFavorite model)
        {
            return _userFavoriteRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _userFavoriteRepository.Delete(id);
        }

        public UserFavorite Get(int id)
        {
            return _userFavoriteRepository.Get(id);
        }

        public List<UserFavorite> GetAll()
        {
            return _userFavoriteRepository.GetAll();
        }

        public UserFavoriteComplexResult Search(UserFavorite sm, out int recordCount)
        {
            return _userFavoriteRepository.Search(sm, out recordCount);
        }
    }
}
