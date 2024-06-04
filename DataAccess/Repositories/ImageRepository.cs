using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;

using DomainModel.Assist;
using DomainModel.DTO.Image;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ImageRepository:IImageRepository
    {
        private readonly ShikaShopContext db;

        public ImageRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Image model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                model.Picture = "";
                db.Images.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New image succeed", model.ImageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New image failed in repository ="+ex.Message, model.ImageId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.Images.FirstOrDefault(x => x.ImageId == id);
                if (result!=null)
                {
                    db.Images.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete image succeed", id);
                }

                return op.Failed("image not Found", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Image failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Image model)
        {
            OperationResult op = new OperationResult("Update", model.ImageId);
            try
            {
                db.Images.Attach(model);
                db.Entry<Image>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update image succeed", model.ImageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update image failed in repository =" + ex.Message, model.ImageId);
            }
        }

        public Image Get(int id)
        {
            var result = db.Images.FirstOrDefault(x => x.ImageId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<Image> GetAll()
        {
            return db.Images.ToList();
        }

        public ImageComplexResults Search(ImageSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Images
                    select new ImageSearchResult
                    {
                        ImageId = item.ImageId,
                        UserId = item.UserId,
                        EmployeeId = item.EmployeeId,
                        EmployeeName = item.Employee.FirstName+item.Employee.LastName,
                        ImageCode = item.ImageCode,
                        ImageUrl = item.ImageUrl,
                        ImageName = item.ImageName,
                        ProductId = item.ProductId,
                        ProductName = item.Product.ProductName,
                        UserName = item.User.UserName,
                    };
                if (!string.IsNullOrEmpty(sm.EmployeeName))
                {
                    results = results.Where(x => x.EmployeeName.StartsWith(sm.EmployeeName));
                }
                if (!string.IsNullOrEmpty(sm.ImageCode))
                {
                    results = results.Where(x => x.ImageCode.StartsWith(sm.ImageCode));
                }
                if (!string.IsNullOrEmpty(sm.ImageUrl))
                {
                    results = results.Where(x => x.ImageUrl.StartsWith(sm.ImageUrl));
                }
                if (!string.IsNullOrEmpty(sm.ImageName))
                {
                    results = results.Where(x => x.ImageName.StartsWith(sm.ImageName));
                }
                if (!string.IsNullOrEmpty(sm.ProductName))
                {
                    results = results.Where(x => x.ProductName.StartsWith(sm.ProductName));
                }
                if (!string.IsNullOrEmpty(sm.UserName))
                {
                    results = results.Where(x => x.UserName.StartsWith(sm.UserName));
                }


                recordCount = results.Count();
                return new ImageComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new ImageComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
