using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Product;
using DomainModel.DTO.Tax;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DataAccess.Repositories
{
    public class TaxRepository:ITaxRepository
    {
        private readonly ShikaShopContext db;

        public TaxRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Tax model)
        {
            OperationResult op = new OperationResult("Add New ");
            try
            {
                if (HasTax(model.TaxName))
                {
                    return op.Failed("this tax has exist", model.TaxId);
                }
                db.Taxes.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New tax succeed",model.TaxId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Tax failed in repository =" + ex.Message, model.TaxId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete ", id);
            try
            {
                var result = db.Taxes.FirstOrDefault(x => x.TaxId == id);
                if (result != null)
                {
                    db.Taxes.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete tax succeed ", id);
                }

                return op.Failed("this tax not found", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Tax failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Tax model)
        {
            OperationResult op = new OperationResult("Update", model.TaxId);
            try
            {
                db.Taxes.Attach(model);
                db.Entry<Tax>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Tax Succeed", model.TaxId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Tax failed in repository =" + ex.Message, model.TaxId);
            }
        }

        public Tax Get(int id)
        {
            var result = db.Taxes.FirstOrDefault(x => x.TaxId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<Tax> GetAll()
        {
            return db.Taxes.ToList();
        }

        public TaxComplexResults Search(TaxSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Taxes
                              select new TaxSearchResult
                              {
                                  TaxId = item.TaxId,
                                  TaxName = item.TaxName,
                                  TaxPercent = item.TaxPercent,
                              };
                if (!string.IsNullOrEmpty(sm.TaxName))
                {
                    results = results.Where(x => x.TaxName.StartsWith(sm.TaxName));
                }
                if (sm.TaxPercent != null)
                {
                    results = results.Where(x => x.TaxPercent == sm.TaxPercent);
                }





                recordCount = results.Count();
                return new TaxComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new TaxComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }

        public bool HasTax(string name)
        {
            return db.Taxes.Any(x => x.TaxName == name);
        }
    }
}
