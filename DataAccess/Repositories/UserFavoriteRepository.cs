
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.UserFavorite;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserFavoriteRepository: IUserFavoriteRepository
    {
        private readonly ShikaShopContext db;

        public UserFavoriteRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(UserFavorite model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.UserFavorites.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.UserFavoriteId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.UserFavoriteId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.UserFavorites.FirstOrDefault(x => x.UserFavoriteId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.UserFavorites.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(UserFavorite model)
        {
            OperationResult op = new OperationResult("Update", model.UserFavoriteId);
            try
            {
                db.UserFavorites.Attach(model);
                db.Entry<UserFavorite>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.UserFavoriteId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.UserFavoriteId);
            }
        }

        public UserFavorite Get(int id)
        {
            return db.UserFavorites.FirstOrDefault(x => x.UserFavoriteId == id);
        }

        public List<UserFavorite> GetAll()
        {
            return db.UserFavorites.ToList();
        }

        public UserFavoriteComplexResult Search(UserFavorite sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.UserFavorites
                    select new UserFavorite
                    {
                        UserId = item.UserId,
                        FavoriteId = item.FavoriteId,
                        UserFavoriteId = item.UserFavoriteId
                    };
                if (sm.UserId != 0)
                {
                    results = results.Where(x => x.UserId == sm.UserId);
                }
                if (sm.FavoriteId != 0)
                {
                    results = results.Where(x => x.FavoriteId == sm.FavoriteId);
                }

                recordCount = results.Count();
                return new UserFavoriteComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new UserFavoriteComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
