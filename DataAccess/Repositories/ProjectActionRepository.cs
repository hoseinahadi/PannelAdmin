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
    public class ProjectActionRepository:IProjectActionRepository
    {
        private readonly ShikaShopContext db;

        public ProjectActionRepository(ShikaShopContext db)
        {
            this.db = db;
        }


        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Project Action");
            try
            {
                var action = db.ProjectActions.FirstOrDefault(x => x.ProjectActionId == id);
                if (action==null)
                {
                    return op.Failed("این اکشن یافت نشد ", id);
                }

                db.ProjectActions.Remove(action);
                db.SaveChanges();
                return op.Succeed("حذف با موفقیت همراه بود ", id);
            }
            catch (Exception ex)
            {
                return op.Failed("حذف اکشن با خطا در ریپوزیتوری همراه بود متن خطا ="+ex.Message, id);
            }
        }

        public OperationResult Update(ProjectAction current)
        {
            OperationResult op = new OperationResult("Update Project Action");
            try
            {
                db.ProjectActions.Attach(current);
                db.Entry<ProjectAction>(current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("اپدیت با موفقیت انجام شد", current.ProjectActionId);
            }
            catch (Exception ex)
            {
                return op.Failed("اپدیت با خطا در ریپوزیتوری همراه بود متن خطا =" + ex.Message,
                    current.ProjectActionId);
            }
        }

        public OperationResult Add(ProjectAction current)
        {
            OperationResult op = new OperationResult("Add New Project Action");
            try
            {
                db.ProjectActions.Add(current);
                db.SaveChanges();
                return op.Succeed("با موفقیت اضافه شد ", current.ProjectActionId);
            }
            catch (Exception ex)
            {
                return op.Failed("اضافه کردن با خطا در ریپوزیتوری همرا بود متن خطا =" + ex.Message,
                    current.ProjectActionId);
            }
        }

        public ProjectAction Get(int id)
        {
            var result = db.ProjectActions.FirstOrDefault(x => x.ProjectActionId == id);
            return result;
        }

        public List<ProjectAction> GetAll()
        {
            return db.ProjectActions.ToList();
        }
    }
}
