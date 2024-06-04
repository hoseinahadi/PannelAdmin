using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.GuestUser;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class GuestUserRepository:IGuestUserRepository
    {
        private readonly ShikaShopContext db;

        public GuestUserRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(GuestUser model)
        {
            OperationResult op = new OperationResult("Add New Guest User");
            try
            {
                db.GuestUsers.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New GuestUser Succeed ", model.GuestUserId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New GuestUser Failed in repository =" + ex.Message,model.GuestUserId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete ", id);
            try
            {
                var result = db.GuestUsers.FirstOrDefault(x => x.GuestUserId == id);
                if (result!=null)
                {
                    db.GuestUsers.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("delete GuestUser Succeed", id);
                }

                return op.Failed("this GuestUser not Exist", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete GuestUser failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(GuestUser model)
        {
            OperationResult op = new OperationResult("Update", model.GuestUserId);
            try
            {
                db.GuestUsers.Attach(model);
                db.Entry<GuestUser>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update GuestUser Succeed ", model.GuestUserId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update GuestUser failed in repository =" + ex.Message, model.GuestUserId);
            }
        }

        public GuestUser Get(int id)
        {
            var result = db.GuestUsers.FirstOrDefault(x => x.GuestUserId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<GuestUser> GetAll()
        {
            return db.GuestUsers.ToList();
        }

        public GuestUserComplexResults Search(GuestUserSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.GuestUsers
                    select new GuestUserSearchResult
                    {
                        WebBrowserId = item.WebBrowserId,
                        AcceptLanguage = item.AcceptLanguage,
                        AdobeFlash = item.AdobeFlash,
                        ConnectionId = item.ConnectionId,
                        GuestUserId = item.GuestUserId,
                        ScreenResolutionY = item.ScreenResolutionY,
                        JavaScript = item.JavaScript,
                        ScreenResolutionX = item.ScreenResolutionX

                    };
                if (sm.ScreenResolutionX != 0)
                {
                    results = results.Where(x => x.ScreenResolutionX == sm.ScreenResolutionX);
                }
                if (sm.ScreenResolutionY != 0)
                {
                    results = results.Where(x => x.ScreenResolutionY == sm.ScreenResolutionY);
                }
                if (!string.IsNullOrEmpty(sm.AcceptLanguage))
                {
                    results = results.Where(x => x.AcceptLanguage.StartsWith(sm.AcceptLanguage));
                }


                recordCount = results.Count();
                return new GuestUserComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new GuestUserComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
