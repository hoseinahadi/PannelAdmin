using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;

using DomainModel.Assist;
using DomainModel.DTO.ContactUs;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ContactUsRepository:IContactUsRepository
    {
        private readonly ShikaShopContext db;

        public ContactUsRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ContactUs model)
        {
            OperationResult op = new OperationResult("Add New ContactUs");
            try
            {
                db.ContactUsEnumerable.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New ContactUss Success",model.ContactUsId);

            }
            catch (Exception ex)
            {
                return op.Failed("Add New ContactUs Failed in repository =" + ex.Message, model.ContactUsId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete ContactUs",id);
            try
            {
                var result = db.ContactUsEnumerable.FirstOrDefault(x => x.ContactUsId == id);
                db.ContactUsEnumerable.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete ContactUs Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete ContactUs failed in repository = " + ex.Message, id);
            }
        }

        public OperationResult Update(ContactUs model)
        {
            OperationResult op = new OperationResult("Update ContactUs",model.ContactUsId);
            try
            {
                db.ContactUsEnumerable.Attach(model);
                db.Entry<ContactUs>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update ContactUs Success", model.ContactUsId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update ContactUs Failed in repository = " + ex.Message, model.ContactUsId);
            }
        }

        public ContactUs Get(int id)
        {
            return db.ContactUsEnumerable.FirstOrDefault(x => x.ContactUsId == id);
        }

        public List<ContactUs> GetAll()
        {
            return db.ContactUsEnumerable.ToList();
        }

        public ContactUsComplexResults Search(ContactUsSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.ContactUsEnumerable
                    select new ContactUsSearchResult
                    {
                        ContactUsId = item.ContactUsId,
                        Phone = item.Phone,
                        Description = item.Description,
                        Email = item.Email,
                    };

                recordCount = results.Count();
                return new ContactUsComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new ContactUsComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
