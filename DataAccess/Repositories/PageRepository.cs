using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;

using DomainModel.Assist;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PageRepository:IPageRepository
    {
        private readonly ShikaShopContext db;

        public PageRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Page model)
        {
            OperationResult op = new OperationResult("Add New ");
            try
            {
                if (HasPage(model.PageName))
                {
                    return op.Failed("this page Exist", model.PageId);
                }
                db.Pages.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Page succeed", model.PageId);

            }
            catch (Exception ex)
            {
                return op.Failed("Add New Page failed in repository =" + ex.Message, model.PageId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.Pages.FirstOrDefault(x => x.PageId == id);
                if (result != null)
                {
                    db.Pages.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete page succeed", id);
                }

                return op.Failed("This page not found", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Page failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Page model)
        {
            OperationResult op = new OperationResult("Update", model.PageId);
            try
            {
                db.Pages.Attach(model);
                db.Entry<Page>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update page succeed", model.PageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update page failed in repository =" + ex.Message, model.PageId);
            }
        }

        public Page Get(int id)
        {
            var result = db.Pages.FirstOrDefault(x => x.PageId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<Page> GetAll()
        {
            return db.Pages.ToList();
        }

        public bool HasPage(string name)
        {
            return db.Pages.Any(x => x.PageName == name);
        }
    }
}
