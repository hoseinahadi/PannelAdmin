using DataAccessServices.Services.Base;
using DomainModel.DTO.Cart;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ICartRepository:IBaseRepositorySearchable<Cart,int,CartSearchModel,CartComplexResult>
    {

    }
}
