using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Cart;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CartRepository:ICartRepository
    {
        private readonly ShikaShopContext db;

        public CartRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Cart model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                
                db.Carts.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Cart success", model.CartId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Cart Failed in Repository =" + ex.Message, model.CartId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var cart = db.Carts.FirstOrDefault(x => x.CartId == id);
                db.Carts.Remove(cart);
                db.SaveChanges();
                return op.Succeed("Delete Cart Success",id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Cart failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Cart model)
        {
            OperationResult op = new OperationResult("Update", model.CartId);
            try
            {
                db.Carts.Attach(model);
                db.Entry<Cart>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Cart success", model.CartId);

            }
            catch (Exception ex)
            {

                return op.Failed("Update Cart Failed in repository =" + ex.Message, model.CartId);
            }
        }

        public Cart Get(int id)
        {
            return db.Carts.FirstOrDefault(x => x.CartId == id);
        }

        public List<Cart> GetAll()
        {
            return db.Carts.ToList();
        }

        public CartComplexResult Search(CartSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Carts
                    select new CartSearchResults
                    {
                        UserId = item.UserId,
                        AddDate = item.AddDate,
                        CartId = item.CartId,
                        
                    };
                if (sm.UserId!=null)
                {
                    results = results.Where(x => x.UserId==sm.UserId);
                }
                if (sm.AddDate != null)
                {
                    results = results.Where(x => x.AddDate == sm.AddDate);
                }
                recordCount = results.Count();
                return new CartComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new CartComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
