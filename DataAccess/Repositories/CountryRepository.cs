using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Country;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CountryRepository:ICountryRepository
    {
        private readonly ShikaShopContext db;

        public CountryRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Country model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                if (DuplicateCountry(model.CountryName))
                {
                    return op.Failed("This country exist", model.CountryId);
                }

                db.Countries.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Country Success", model.CountryId);

            }
            catch (Exception ex)
            {
                return op.Failed("Add New Country failed in repository =" + ex.Message, model.CountryId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.Countries.FirstOrDefault(x => x.CountryId == id);
                if (result==null)
                {
                    return op.Failed("this Country Not Found", id);
                }
                db.Countries.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Country Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Country failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Country model)
        {
            OperationResult op = new OperationResult("Update", model.CountryId);
            try
            {
                db.Countries.Attach(model);
                db.Entry<Country>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Country Success", model.CountryId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Country Failed in repository =" + ex.Message, model.CountryId);
            }
        }

        public Country Get(int id)
        {
            return db.Countries.FirstOrDefault(x => x.CountryId == id);
        }

        public List<Country> GetAll()
        {
            return db.Countries.ToList();
        }

        public CountryComplexResults Search(CountrySearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Countries
                    select new CountrySearchResult
                    {
                        CountryCode = item.CountryCode,
                        CountryName = item.CountryName,
                        CountryId = item.CountryId,
                    };
                if (sm.CountryCode != null)
                {
                    results = results.Where(x => x.CountryCode == sm.CountryCode);
                }
                if (!string.IsNullOrEmpty(sm.CountryName))
                {
                    results = results.Where(x => x.CountryName.StartsWith(sm.CountryName));
                }
                recordCount = results.Count();
                return new CountryComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new CountryComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }

        public bool DuplicateCountry(string name)
        {
            return db.Countries.Any(x => x.CountryName == name);
        }
    }
}
