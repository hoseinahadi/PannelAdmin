using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Currency;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CurrencyRepository:ICurrencyRepository
    {
        private readonly ShikaShopContext db;

        public CurrencyRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Currency model)
        {
            OperationResult op = new OperationResult("Add New Currency");
            try
            {
                if (HasCurrency(model.CurrencyName))
                {
                    return op.Failed("This currency exist", model.CurrencyId);
                }
                db.Currencies.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Currency Success", model.CurrencyId);
            }
            catch (Exception ex)
            {
                return op.Failed("add new Currency failed in repository =" + ex.Message, model.CurrencyId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Currency");
            try
            {
                var result = db.Currencies.FirstOrDefault(x => x.CurrencyId == id);
                db.Currencies.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Currency Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Currency failed in repository", id);
            }
        }

        public OperationResult Update(Currency model)
        {
            OperationResult op = new OperationResult("Update", model.CurrencyId);
            try
            {
                db.Currencies.Attach(model);
                db.Entry<Currency>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Currency Success", model.CurrencyId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Currency Failed in repository =" + ex.Message, model.CurrencyId);
            }
        }

        public Currency Get(int id)
        {
            return db.Currencies.FirstOrDefault(x => x.CurrencyId == id);
        }

        public List<Currency> GetAll()
        {
            return db.Currencies.ToList();
        }

        public CurrencyComplexResults Search(CurrencySearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Currencies
                    select new CurrencySearchResult
                    {
                        CurrencyId = item.CurrencyId,
                        ConversionRate = item.ConversionRate,
                        CurrencyName = item.CurrencyName,
                    };
                if (!string.IsNullOrEmpty(sm.CurrencyName))
                {
                    results = results.Where(x => x.CurrencyName.StartsWith(sm.CurrencyName));
                }
                recordCount = results.Count();
                return new CurrencyComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new CurrencyComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }

        public bool HasCurrency(string name)
        {
            return db.Currencies.Any(x => x.CurrencyName == name);
        }
    }
}
