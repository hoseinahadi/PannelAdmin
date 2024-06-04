using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Discount;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class DiscountRepository:IDiscountRepository
    {
        private readonly ShikaShopContext db;

        public DiscountRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Discount model)
        {
            OperationResult op = new OperationResult("Add New Discount");
            try
            {
                db.Discounts.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Discount Success", model.DiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Discount failed in repository =" + ex.Message, model.DiscountId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Discount", id);
            try
            {
                var result = db.Discounts.FirstOrDefault(x => x.DiscountId == id);
                if (result != null)
                {
                    db.Discounts.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete Discount Succeed", id);
                }

                return op.Failed("this discount not Found ", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Discount failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Discount model)
        {
            OperationResult op = new OperationResult("Update ", model.DiscountId);
            try
            {
                db.Discounts.Attach(model);
                db.Entry<Discount>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Discount Succeed ", model.DiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update discount failed in repository =" + ex.Message, model.DiscountId);
            }
        }

        public Discount Get(int id)
        {
            return db.Discounts.FirstOrDefault(x => x.DiscountId == id);

        }

        public List<Discount> GetAll()
        {
            return db.Discounts.ToList();
        }

        public DiscountComplexResults Search(DiscountSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Discounts
                    select new DiscountSearchResult
                    {
                        Name = item.Name,
                        DiscountId = item.DiscountId,
                        Percent = item.Percent,
                        
                    };
                
                if (!string.IsNullOrEmpty(sm.Name))
                {
                    results = results.Where(x => x.Name.StartsWith(sm.Name));
                }
                recordCount = results.Count();
                return new DiscountComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new DiscountComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
