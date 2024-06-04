
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.EmployeeMessage;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EmployeeMessageRepository: IEmployeeMessageRepository
    {
        private readonly ShikaShopContext db;

        public EmployeeMessageRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(EmployeeMessage model)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {
                db.EmployeeMessages.Add(model);
                db.SaveChanges();
                return op.Succeed("Success", model.EmployeeMessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New failed in Repository = " + ex.Message,
                    model.EmployeeMessageId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            try
            {
                var result = db.EmployeeMessages.FirstOrDefault(x => x.EmployeeMessageId == id);
                if (result == null)
                {
                    return op.Failed("this is not found", id);
                }
                db.EmployeeMessages.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete failed in repository" + ex.Message, id);
            }
        }

        public OperationResult Update(EmployeeMessage model)
        {
            OperationResult op = new OperationResult("Update", model.EmployeeMessageId);
            try
            {
                db.EmployeeMessages.Attach(model);
                db.Entry<EmployeeMessage>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update  Success", model.EmployeeMessageId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update  Failed in Repository =" + ex.Message, model.EmployeeMessageId);
            }
        }

        public EmployeeMessage Get(int id)
        {
            return db.EmployeeMessages.FirstOrDefault(x => x.EmployeeMessageId == id);
        }

        public List<EmployeeMessage> GetAll()
        {
            return db.EmployeeMessages.ToList();
        }

        public EmployeeMessageComplexResult Search(EmployeeMessage sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.EmployeeMessages
                    select new EmployeeMessage
                    {
                        EmployeeId = item.EmployeeId,
                        EmployeeMessageId = item.EmployeeMessageId,
                        MessageId = item.MessageId,
                    };
                if (sm.EmployeeId != 0)
                {
                    results = results.Where(x => x.EmployeeId == sm.EmployeeId);
                }
                if (sm.MessageId != 0)
                {
                    results = results.Where(x => x.MessageId == sm.MessageId);
                }

                recordCount = results.Count();
                return new EmployeeMessageComplexResult
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new EmployeeMessageComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
