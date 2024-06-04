using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;

using DomainModel.Assist;
using DomainModel.DTO.Product;
using DomainModel.DTO.Supplier;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SupplierRepository:ISupplierRepository
    {
        private readonly ShikaShopContext db;

        public SupplierRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Supplier model)
        {
            OperationResult op = new OperationResult("Add new ");
            try
            {
                if (HasSupplier(model.SupplierName))
                {
                    return op.Failed("this supplier exist", model.SupplierId);
                }
                db.Suppliers.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New supplier succeed", model.SupplierId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Supplier failed in repository =" + ex.Message, model.SupplierId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.Suppliers.FirstOrDefault(x => x.SupplierId == id);
                if (result != null)
                {
                    db.Suppliers.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete supplier succeed", id);
                }

                return op.Failed("this supplier not found", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete supplier failed in repository ="+ex.Message, id);
            }
        }

        public OperationResult Update(Supplier model)
        {
            OperationResult op = new OperationResult("Update",model.SupplierId);
            try
            {
                db.Suppliers.Attach(model);
                db.Entry<Supplier>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Supplier succeed", model.SupplierId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Supplier failed in repository =" + ex.Message, model.SupplierId);
            }
        }

        public Supplier Get(int id)
        {
            var result = db.Suppliers.FirstOrDefault(x=>x.SupplierId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public SupplierComplexResults Search(SupplierSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Suppliers
                              select new SupplierSearchResult
                              {
                                  SupplierId = item.SupplierId,
                                  Note = item.Note,
                                  PhoneNumber = item.PhoneNumber,
                                  SupplierName = item.SupplierName,
                              };
                if (!string.IsNullOrEmpty(sm.Note))
                {
                    results = results.Where(x => x.Note.StartsWith(sm.Note));
                }
                if (!string.IsNullOrEmpty(sm.PhoneNumber))
                {
                    results = results.Where(x => x.PhoneNumber.StartsWith(sm.PhoneNumber));
                }
                if (!string.IsNullOrEmpty(sm.SupplierName))
                {
                    results = results.Where(x => x.SupplierName.StartsWith(sm.SupplierName));
                }






                recordCount = results.Count();
                return new SupplierComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new SupplierComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }

        public bool HasSupplier(string name)
        {
            return db.Suppliers.Any(x => x.SupplierName == name);
        }
    }
}
