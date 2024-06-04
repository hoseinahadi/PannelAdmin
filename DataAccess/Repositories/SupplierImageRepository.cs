
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.SupplierImage;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class SupplierImageRepository : ISupplierImageRepository
    {
        private readonly ShikaShopContext db;

        public SupplierImageRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(SupplierImage model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.SupplierImages.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.SupplierImageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.SupplierImageId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.SupplierImages.FirstOrDefault(x => x.SupplierImageId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.SupplierImages.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(SupplierImage model)
        {
            OperationResult op = new OperationResult("Update", model.SupplierImageId);
            try
            {
                db.SupplierImages.Attach(model);
                db.Entry<SupplierImage>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.SupplierImageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.SupplierImageId);
            }
        }

        public SupplierImage Get(int id)
        {
            return db.SupplierImages.FirstOrDefault(x => x.SupplierImageId == id);
        }

        public List<SupplierImage> GetAll()
        {
            return db.SupplierImages.ToList();
        }

        public SupplierImageComplexResult Search(SupplierImage sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.SupplierImages
                    select new SupplierImage
                    {
                        SupplierImageId = item.SupplierImageId,
                        SupplierId = item.SupplierId,
                        ImageId = item.ImageId,
                    };
                if (sm.SupplierId != 0)
                {
                    results = results.Where(x => x.SupplierId == sm.SupplierId);
                }
                if (sm.ImageId != 0)
                {
                    results = results.Where(x => x.ImageId == sm.ImageId);
                }

                recordCount = results.Count();
                return new SupplierImageComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new SupplierImageComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
