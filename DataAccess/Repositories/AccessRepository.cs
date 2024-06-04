using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Access;
using DomainModel.DTO.Category;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AccessRepository:IAccessRepository
    {
        private readonly ShikaShopContext db;

        public AccessRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Access model)
        {
            OperationResult op = new OperationResult("Add New");
            if (HasDuplicateAccess(model.AccessLevel))
            {
                return op.Failed("This access Level Exist", model.AccessId);
            }
            try
            {
                db.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Access Success", model.AccessId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Accsess Has Erorr in repository =" + ex.Message, model.AccessId);
            }
            
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            var result = db.Accesses.FirstOrDefault(x => x.AccessId == id);
            if (result == null)
            {
                return op.Failed("This Access Level Not Found", id);
            }
            try
            {
                db.Accesses.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Access Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Access Has error in repository = " + ex.Message, id);
            }
        }

        public OperationResult Update(Access model)
        {
            OperationResult op = new OperationResult("Update", model.AccessId);
            try
            {
                db.Accesses.Attach(model);
                db.Entry<Access>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Access Success", model.AccessId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Access Has error in repository +" + ex.Message, model.AccessId);
            }
        }

        public Access Get(int id)
        {
            return db.Accesses.FirstOrDefault(x => x.AccessId == id);
        }

        public List<Access> GetAll()
        {
            return db.Accesses.ToList();
        }

        public AccessComplexResult Search(AccessSearchModel sm, out int recordCount)
        {
            List<string> Error = new List<string>();
            recordCount = 0;
            try
            {
                var result = from item in db.Accesses
                             select new AccessSearchResult
                             {
                                 AccessId = item.AccessId,
                                 AccessLevel = item.AccessLevel
                             };
                if (!string.IsNullOrEmpty(sm.AccessLevel))
                {
                    result = result.Where(x => x.AccessLevel.StartsWith(sm.AccessLevel));
                }

                recordCount = result.Count();
                //CategorySearchResult = result.Skip()
                AccessComplexResult results = new AccessComplexResult
                {
                    Errors = null,
                    MainResults = result.OrderByDescending(x=>x.AccessId).ToList()
                };
                return results;
            }
            catch (Exception ex)
            {
                Error.Add(ex.Message);
                AccessComplexResult results = new AccessComplexResult
                {
                    Errors = Error,
                    MainResults = null
                };
                return results;
            }
        }

        public bool HasRelatedEmployee(int Id)
        {
            return db.Employees.Any(x => x.AccessId == Id);
            
        }

        public bool HasDuplicateAccess(string name)
        {
            var q = db.Accesses.Any(x => x.AccessLevel == name);
            return q;
        }
    }
}
