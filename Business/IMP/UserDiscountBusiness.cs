using System.Collections.Generic;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.UserDiscount;
using DomainModel.Models;

namespace Business.IMP
{
    public class UserDiscountBusiness:IUserDiscountBusiness
    {
        private readonly IUserDiscountRepository _userDiscountRepository;

        public UserDiscountBusiness(IUserDiscountRepository userDiscountRepository)
        {
            _userDiscountRepository = userDiscountRepository;
        }
        public OperationResult Add(UserDiscount model)
        {
            return _userDiscountRepository.Add(model);
        }

        public OperationResult Update(UserDiscount model)
        {
            return _userDiscountRepository.Update(model);
        }

        public OperationResult Delete(int id)
        {
            return _userDiscountRepository.Delete(id);
        }

        public UserDiscount Get(int id)
        {
            return _userDiscountRepository.Get(id);
        }

        public List<UserDiscount> GetAll()
        {
            return _userDiscountRepository.GetAll();
        }

        public UserDiscountComplexResult Search(UserDiscount sm, out int recordCount)
        {
            return _userDiscountRepository.Search(sm, out recordCount);
        }
    }
}
