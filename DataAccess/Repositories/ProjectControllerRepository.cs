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
    public class ProjectControllerRepository:IProjectControllerRepository
    {
        private readonly ShikaShopContext db;

        public ProjectControllerRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Project Controller");
            try
            {
                var result = db.ProjectControllers.FirstOrDefault(x => x.ProjectControllerId == id);
                if (result == null)
                {
                    return op.Failed("این کنتلر یافت نشد ", id);
                }

                db.ProjectControllers.Remove(result);
                db.SaveChanges();
                return op.Succeed("حذف با موفقیت همراه بود ", id);
            }
            catch (Exception ex)
            {
                return op.Failed("حذف اکشن با خطا در ریپوزیتوری همراه بود متن خطا =" + ex.Message, id);
            }
        }

        public OperationResult Update(ProjectController current)
        {
            OperationResult op = new OperationResult("Update Project Controller");
            try
            {
                db.ProjectControllers.Attach(current);
                db.Entry<ProjectController>(current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("اپدیت با موفقیت انجام شد", current.ProjectControllerId);
            }
            catch (Exception ex)
            {
                return op.Failed("اپدیت با خطا در ریپوزیتوری همراه بود متن خطا =" + ex.Message,
                    current.ProjectControllerId);
            }
        }

        public OperationResult Add(ProjectController current)
        {
            OperationResult op = new OperationResult("Add New Project Controller");
            try
            {
                db.ProjectControllers.Add(current);
                db.SaveChanges();
                return op.Succeed("با موفقیت اضافه شد ", current.ProjectControllerId);
            }
            catch (Exception ex)
            {
                return op.Failed("اضافه کردن با خطا در ریپوزیتوری همرا بود متن خطا =" + ex.Message,
                    current.ProjectControllerId);
            }
        }

        public ProjectController Get(int id)
        {
            var result = db.ProjectControllers.FirstOrDefault(x => x.ProjectControllerId == id);
            return result;
        }

        public List<ProjectController> GetAll()
        {
            return db.ProjectControllers.ToList();
        }
    }
}
