using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Product;
using DomainModel.DTO.User;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ShikaShopContext db;

        public UserRepository(ShikaShopContext db)
        {
            this.db = db;
        }

        public OperationResult Add(User model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                if (model.LastPassword==null)
                {
                    model.LastPassword = "";
                }
                if (model.Phone == null)
                {
                    model.Phone = "";
                }
                if (HasDuplicateUserName(model.UserName))
                {
                    return op.Failed(" این نام کاربری وجود دارد ", model.UserId);
                }
                db.Users.Add(model);
                db.SaveChanges();
                return op.Succeed(" کاربر با موفقیت اضافه شد ", model.UserId);
            }
            catch (Exception ex)
            {
                return op.Failed("خطا در ریپوزیتوری  =" + ex.Message, model.UserId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.Users.FirstOrDefault(x => x.UserId == id);
                if (result != null)
                {
                    db.Users.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete user succeed", id);
                }

                return op.Failed("This user not found ", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete User failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(User model)
        {
            OperationResult op = new OperationResult("Update", model.UserId);
            try
            {
                db.Users.Attach(model);
                db.Entry<User>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update user succeed", model.UserId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update User failed in repository =" + ex.Message, model.UserId);
            }
        }

        public User Get(int id)
        {
            var result = db.Users.FirstOrDefault(x => x.UserId == id);
            
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public UserComplexResults Search(UserSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                
                var results = from item in db.Users 
                              select new UserSearchResult
                              {
                                  AddDate = item.AddDate,
                                  Active = item.Active,
                                  BirthDay = item.BirthDay,
                                  Email = item.Email,
                                  FirstName = item.FirstName,
                                  LastName = item.LastName,
                                  GenderId = item.GenderId,
                                  LastPassword = item.LastPassword,
                                  Password = item.Password,
                                  Phone = item.Phone,
                                  UserId = item.UserId,
                                  UserName = item.UserName,

                              };
                if (!string.IsNullOrEmpty(sm.Email))
                {
                    results = results.Where(x => x.Email.StartsWith(sm.Email));
                }
                if (!string.IsNullOrEmpty(sm.FirstName))
                {
                    results = results.Where(x => x.FirstName.StartsWith(sm.FirstName));
                }
                if (!string.IsNullOrEmpty(sm.LastName))
                {
                    results = results.Where(x => x.LastName.StartsWith(sm.LastName));
                }
                if (!string.IsNullOrEmpty(sm.Phone))
                {
                    results = results.Where(x => x.Phone.StartsWith(sm.Phone));
                }
                if (!string.IsNullOrEmpty(sm.UserName))
                {
                    results = results.Where(x => x.UserName.StartsWith(sm.UserName));
                }
                if (sm.AddDate != null)
                {
                    results = results.Where(x => x.AddDate == sm.AddDate);
                }
                if (sm.Active != null)
                {
                    results = results.Where(x => x.Active == sm.Active);
                }
                if (sm.BirthDay != null)
                {
                    results = results.Where(x => x.BirthDay == sm.BirthDay);
                }






                recordCount = results.Count();
                return new UserComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new UserComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }

        public bool HasDuplicateUserName(string userName)
        {
            return db.Users.Any(x => x.UserName == userName);
        }

        public User GetUserByUserName(string userName)
        {
            return db.Users.FirstOrDefault(x => x.UserName == userName);
        }

        public List<User> GetUserBuRole(string RoleName)
        {
            var roleId = db.Roles.FirstOrDefault(x => x.RoleName == RoleName).RoleId;
            var userList = new List<User>();
            var result = db.Users.ToList();
            foreach (var item in result)
            {
                if (item.RoleId==roleId)
                {
                    userList.Add(item);
                }
            }

            return userList;
        }
    }
}
