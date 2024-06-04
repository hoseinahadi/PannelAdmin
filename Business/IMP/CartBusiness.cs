using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Carrier;
using DomainModel.DTO.Cart;
using DomainModel.Models;

namespace Business.IMP
{
    public class CartBusiness:ICartBusiness
    {
        private readonly ICartRepository repo;
        private readonly IProductCartRepository productCartRepository;

        public CartBusiness(ICartRepository repo, IProductCartRepository productCartRepository)
        {
            this.repo = repo;
            this.productCartRepository = productCartRepository;
        }
        private Cart ToModel(CartAddOrEditModel addOrEdit)
        {
            return new Cart
            {
                UserId = addOrEdit.UserId,
                AddDate = addOrEdit.AddDate,
                CartId = addOrEdit.CartId,
                
                
                
            };
        }
        private CartAddOrEditModel ToAddEditModel(Cart model)
        {
            return new CartAddOrEditModel
            {
                UserId = model.UserId,
                AddDate = model.AddDate,
                CartId = model.CartId,
                
                 
                 
            };
        }
        public OperationResult Add(CartAddOrEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(CartAddOrEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public CartAddOrEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Cart> GetAll()
        {
            return repo.GetAll();
        }
    }
}
