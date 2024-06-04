using System;
using System.Linq;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.User;
using DomainModel.Models;
using DomainModel.Models.Context;

namespace DataAccess.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly ShikaShopContext db;

        public AccountRepository(ShikaShopContext db)
        {
            this.db = db;
        }

        public UserInfo GetUserInfo(string userName)
        {
            var userInfos = from user in db.Users
                join role in db.Roles on user.RoleId equals role.RoleId
                where user.UserName == userName
                select new UserInfo
                {
                    FullName = user.FirstName + " " + user.LastName,
                    RoleId = user.RoleId,
                    RoleName = role.RoleName,
                    UserName = user.UserName,
                    UserId = user.UserId
                };
            return userInfos.FirstOrDefault();

        }

        public User GetFullInfo(string userName)
        {
            var userInfo = db.Users.FirstOrDefault(x => x.UserName == userName);
            return userInfo;
        }

        public OperationResult RegisterNewUser(User u)
        {
            OperationResult op = new OperationResult("Register New User");
            try
            {
                db.Users.Add(u);
                db.SaveChanges();
                op.Succeed("User Registered Successfully", u.UserId);
            }
            catch (Exception ex)
            {
                op.Failed("Registration Failed   " + ex.Message, null);

            }
            return op;
        }

        public bool CheckIfUserHasAccess(CheckPermission per)
        {
            var q = from u in db.Users
                join r in db.Roles on u.RoleId equals r.RoleId
                join ra in db.RoleActiones on r.RoleId equals ra.RoleId
                join ac in db.ProjectActions on ra.ProjectActionId equals ac.ProjectActionId
                join co in db.ProjectControllers on ac.ProjectController equals co
                select new
                {
                    co.ProjectControllerName,
                    ac.ProjectActionName
                    ,
                    u.UserName
                    ,
                    ra.HasPermission
                };
            var result = q.First(x =>
                x.UserName == per.UserName && x.ProjectActionName == per.ActionName &&
                x.ProjectControllerName == per.Controller);
            if (result == null)
            {
                return false;
            }

            return result.HasPermission;
        }
    }
}
