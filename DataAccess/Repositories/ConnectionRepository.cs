using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Connection;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ConnectionRepository:IConnectionRepository
    {
        private readonly ShikaShopContext db;

        public ConnectionRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Connection model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                db.Connections.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Connection success", model.ConnectionId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Connection failed in repository =" + ex.Message, model.ConnectionId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete",id);
            try
            {
                var result = db.Connections.FirstOrDefault(x => x.ConnectionId == id);
                db.Connections.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Connection Succeed", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Connection failed in repository = " + ex.Message, id);
            }
        }

        public OperationResult Update(Connection model)
        {
            OperationResult op = new OperationResult("Update", model.ConnectionId);
            try
            {
                db.Connections.Attach(model);
                db.Entry<Connection>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Connection Success", model.ConnectionId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Connection failed in repository =" + ex.Message, model.ConnectionId);
            }
        }

        public Connection Get(int id)
        {
            return db.Connections.FirstOrDefault(x => x.ConnectionId == id);
        }

        public List<Connection> GetAll()
        {
            return db.Connections.ToList();
        }

        public ConnectionComplexResult Search(ConnectionSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Connections
                    select new ConnectionSearchResult
                    {
                        PageId = item.PageId,
                        ConnectionId = item.ConnectionId,
                        EndDate = item.EndDate,
                        StartDate = item.StartDate,
                    };
                if (sm.StartDate != null)
                {
                    results = results.Where(x => x.StartDate == sm.StartDate);
                }
                if (sm.EndDate != null)
                {
                    results = results.Where(x => x.EndDate == sm.EndDate);
                }
                recordCount = results.Count();
                return new ConnectionComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new ConnectionComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
