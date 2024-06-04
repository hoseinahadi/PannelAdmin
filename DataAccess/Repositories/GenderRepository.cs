using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;

using DomainModel.Assist;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class GenderRepository:IGenderRepository
    {
        private readonly ShikaShopContext db;

        public GenderRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Gender model)
        {
            OperationResult op = new OperationResult("Add New Gender");
            try
            {
                if (HasGenderName(model.GenderName))
                {
                    return op.Failed("this gender has exist", model.GenderId);
                }
                db.Genders.Add(model);
                db.SaveChanges();
                return op.Succeed("Add Gender succeed ", model.GenderId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Gender failed in repository =" + ex.Message, model.GenderId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Gender", id);
            try
            {
                var result = db.Genders.FirstOrDefault(x => x.GenderId == id);
                if (result != null)
                {
                    db.Genders.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete Gender Succeed", id);
                }

                return op.Failed("this Feature not Exist", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Gender failed in repository", id);
            }
        }

        public OperationResult Update(Gender model)
        {
            OperationResult op = new OperationResult("Update Gender", model.GenderId);
            try
            {
                db.Genders.Attach(model);
                db.Entry<Gender>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update gender succeed", model.GenderId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Gender failed in repository =", model.GenderId);
            }
        }

        public Gender Get(int id)
        {
            var result = db.Genders.FirstOrDefault(x => x.GenderId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<Gender> GetAll()
        {
            return db.Genders.ToList();
        }

        public bool HasGenderName(string name)
        {
            return db.Genders.Any(x => x.GenderName == name);
        }
    }
}
