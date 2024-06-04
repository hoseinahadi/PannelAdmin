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
    public class OpSystemRepository:IOpSystemRepository
    {
        private readonly ShikaShopContext db;

        public OpSystemRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(OpSystem model)
        {
            OperationResult op = new OperationResult("Add New ");
            try
            {
                if (HasOpSystem(model.OpName))
                {
                    return op.Failed("this OpSystem has Exist", model.OpSystemId);

                }
                db.OpSystems.Add(model);
                db.SaveChanges();   
                return op.Succeed("Add new OpSystem succeed",model.OpSystemId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New OpSystem failed in repository =" + ex.Message, model.OpSystemId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete",id);
            try
            {
                var result = db.OpSystems.FirstOrDefault(x => x.OpSystemId == id);
                if (result != null)
                {
                    db.OpSystems.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete OpSystem Succeed", id);
                }

                return op.Failed("this OpSystem Not found", id); 

            }
            catch (Exception ex)
            {
                return op.Failed("Delete OpSystem failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(OpSystem model)
        {
            OperationResult op = new OperationResult("Update", model.OpSystemId);
            try
            {
                db.OpSystems.Attach(model);
                db.Entry<OpSystem>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update OpSystem Succeed", model.OpSystemId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update OpSystem failed in repository =" + ex.Message, model.OpSystemId);
            }
        }

        public OpSystem Get(int id)
        {
            var result = db.OpSystems.FirstOrDefault(x => x.OpSystemId == id);
            if (result!=null)
            {

                return result;
            }
            return null;
        }

        public List<OpSystem> GetAll()
        {
            return db.OpSystems.ToList();
        }

        public bool HasOpSystem(string name)
        {
            return db.OpSystems.Any(x => x.OpName == name);
        }
    }
}
