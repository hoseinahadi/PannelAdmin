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
    public class WebBrowserRepository:IWebBrowserRepository
    {
        private readonly ShikaShopContext db;

        public WebBrowserRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(WebBrowser model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                if (HasName(model.WebBrowserName))
                {
                    return op.Failed("This Web Browser exist ", model.WebBrowserId);
                }
                db.WebBrowsers.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Web Browser succeed", model.WebBrowserId);

            }
            catch (Exception ex)
            {
                return op.Failed("Add New Web Browser failed din repository =" + ex.Message, model.WebBrowserId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.WebBrowsers.FirstOrDefault(x => x.WebBrowserId == id);

                if (result != null)
                {
                    db.WebBrowsers.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete Web Browser succeed", id);
                }

                return op.Failed("This WebBrowser not found", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Web Browser failed din repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(WebBrowser model)
        {
            OperationResult op = new OperationResult("Update", model.WebBrowserId);
            try
            {
                db.WebBrowsers.Attach(model);
                db.Entry<WebBrowser>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Web Browser succeed", model.WebBrowserId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Web Browser failed din repository =" + ex.Message, model.WebBrowserId);
            }
        }

        public WebBrowser Get(int id)
        {
            var result = db.WebBrowsers.FirstOrDefault(x => x.WebBrowserId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<WebBrowser> GetAll()
        {
            return db.WebBrowsers.ToList();
        }

        public bool HasName(string name)
        {
            return db.WebBrowsers.Any(x => x.WebBrowserName == name);
        }
    }
}
