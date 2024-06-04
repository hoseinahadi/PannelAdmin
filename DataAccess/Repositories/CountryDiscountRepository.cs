using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.CountryDiscount;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CountryDiscountRepository:ICountryDiscountRepository
    {
        private readonly ShikaShopContext db;

        public CountryDiscountRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(CountryDiscount model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.CountryDiscounts.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.CountryDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.CountryDiscountId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.CountryDiscounts.FirstOrDefault(x => x.CountryDiscountId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.CountryDiscounts.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(CountryDiscount model)
        {
            OperationResult op = new OperationResult("Update", model.CountryDiscountId);
            try
            {
                db.CountryDiscounts.Attach(model);
                db.Entry<CountryDiscount>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.CountryDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.CountryDiscountId);
            }
        }

        public CountryDiscount Get(int id)
        {
            return db.CountryDiscounts.FirstOrDefault(x => x.CountryDiscountId == id);
        }

        public List<CountryDiscount> GetAll()
        {
            return db.CountryDiscounts.ToList();
        }

        public CountryDiscountComplexResult Search(CountryDiscount sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.CountryDiscounts
                    select new CountryDiscount
                    {
                        CountryDiscountId = item.CountryDiscountId,
                        Country = item.Country,
                        DiscountId = item.DiscountId,
                    };
                if (sm.CountryId != 0)
                {
                    results = results.Where(x => x.CountryId == sm.CountryId);
                }
                if (sm.DiscountId != 0)
                {
                    results = results.Where(x => x.DiscountId == sm.DiscountId);
                }

                recordCount = results.Count();
                return new CountryDiscountComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new CountryDiscountComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
