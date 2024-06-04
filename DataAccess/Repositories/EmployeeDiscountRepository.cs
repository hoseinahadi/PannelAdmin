using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.EmployeeDiscount;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EmployeeDiscountRepository:IEmployeeDiscountRepository
    {
        private readonly ShikaShopContext db;

        public EmployeeDiscountRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(EmployeeDiscount model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.EmployeeDiscounts.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.EmployeeDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.EmployeeDiscountId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.EmployeeDiscounts.FirstOrDefault(x => x.EmployeeDiscountId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.EmployeeDiscounts.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(EmployeeDiscount model)
        {
            OperationResult op = new OperationResult("Update", model.EmployeeDiscountId);
            try
            {
                db.EmployeeDiscounts.Attach(model);
                db.Entry<EmployeeDiscount>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.EmployeeDiscountId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.EmployeeDiscountId);
            }
        }

        public EmployeeDiscount Get(int id)
        {
            return db.EmployeeDiscounts.FirstOrDefault(x => x.EmployeeDiscountId == id);
        }

        public List<EmployeeDiscount> GetAll()
        {
            return db.EmployeeDiscounts.ToList();
        }

        public EmployeeDiscountComplexResult Search(EmployeeDiscount sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.EmployeeDiscounts
                    select new EmployeeDiscount
                    {
                        EmployeeDiscountId = item.EmployeeDiscountId,
                        EmployeeId = item.EmployeeId,
                        DiscountId = item.DiscountId,
                    };
                if (sm.EmployeeId != 0)
                {
                    results = results.Where(x => x.EmployeeId == sm.EmployeeId);
                }
                if (sm.DiscountId != 0)
                {
                    results = results.Where(x => x.DiscountId == sm.DiscountId);
                }

                recordCount = results.Count();
                return new EmployeeDiscountComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new EmployeeDiscountComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
