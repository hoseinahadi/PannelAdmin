using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly ShikaShopContext db;

        public RoleRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Role");
            try
            {
                var role = db.Roles.FirstOrDefault(x => x.RoleId == id);
                if (role==null)
                {
                    return op.Failed("این رول یافت نشد", id);
                }

                db.Roles.Remove(role);
                db.SaveChanges();
                return op.Succeed("حذف رول با موفقیت انجام شد", id);
            }
            catch (Exception ex)
            {
                return op.Failed("حذف رول با خطا در ریپوزیتوری همراه بود متن خطا ="+ex.Message, id);
            }
        }

        public OperationResult Update(Role current)
        {
            OperationResult op = new OperationResult("Update Role");
            try
            {
                db.Roles.Attach(current);
                db.Entry<Role>(current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("اپدیت با موفقیت انجام شد", current.RoleId);
            }
            catch (Exception ex)
            {
                return op.Failed("اپدیت رول با خطا در ریپوزیتوری همراه بود متن خطا =" + ex.Message, current.RoleId);
            }
        }

        public OperationResult Add(Role current)
        {
            OperationResult op = new OperationResult("Add New Role");
            try
            {
                db.Roles.Add(current);
                db.SaveChanges();
                return op.Succeed("رول با موفقیت اضافه شد", current.RoleId);
            }
            catch (Exception ex)
            {
                return op.Failed("اضافه کردن رول با خطا در ریپوزیتوری همراه بود متن خطا =" + ex.Message,
                    current.RoleId);
            }
        }

        public Role Get(int id)
        {
            var role = db.Roles.FirstOrDefault(x => x.RoleId == id);
            return role;
        }

        public List<Role> GetAll()
        {
            return db.Roles.ToList();
        }
    }
}
