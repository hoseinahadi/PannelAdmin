
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.UserDiscount;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserDiscountRepository: IUserDiscountRepository
    {
        private readonly ShikaShopContext db;

        public UserDiscountRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(UserDiscount model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.UserDiscounts.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.UserDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.UserDiscountId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.UserDiscounts.FirstOrDefault(x => x.UserDiscountId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.UserDiscounts.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(UserDiscount model)
        {
            OperationResult op = new OperationResult("Update", model.UserDiscountId);
            try
            {
                db.UserDiscounts.Attach(model);
                db.Entry<UserDiscount>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.UserDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.UserDiscountId);
            }
        }

        public UserDiscount Get(int id)
        {
            return db.UserDiscounts.FirstOrDefault(x => x.UserDiscountId == id);
        }

        public List<UserDiscount> GetAll()
        {
            return db.UserDiscounts.ToList();
        }

        public UserDiscountComplexResult Search(UserDiscount sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.UserDiscounts
                    select new UserDiscount
                    {
                        UserDiscountId = item.UserDiscountId,
                        UserId = item.UserId,
                        DiscountId = item.DiscountId,
                    };
                if (sm.UserId != 0)
                {
                    results = results.Where(x => x.UserId == sm.UserId);
                }
                if (sm.DiscountId != 0)
                {
                    results = results.Where(x => x.DiscountId == sm.DiscountId);
                }

                recordCount = results.Count();
                return new UserDiscountComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new UserDiscountComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
