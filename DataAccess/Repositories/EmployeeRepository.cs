using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;

using DomainModel.Assist;
using DomainModel.DTO.Employee;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ShikaShopContext db;

        public EmployeeRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Employee model)
        {
            OperationResult op = new OperationResult("Add Employee ");
            try
            {
                db.Employees.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Employee succeed", model.EmployeeId);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Employee failed in repository =" + ex.Message, model.EmployeeId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Employee",id);
            try
            {
                var result = db.Employees.FirstOrDefault(x => x.EmployeeId == id);
                db.Employees.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Employee Succeed", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Employee Failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Employee model)
        {
            OperationResult op = new OperationResult("Update", model.EmployeeId);
            try
            {
                db.Employees.Attach(model);
                db.Entry<Employee>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Employee Succeed", model.EmployeeId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Employee failed in repository =" + ex.Message, model.EmployeeId);
            }
        }

        public Employee Get(int id)
        {
            var result = db.Employees.FirstOrDefault(x=>x.EmployeeId==id);
            if (result!=null)
            {
                return result;
            }

            return null;
        }

        public List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public EmployeeComplexResults Search(EmployeeSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Employees
                    select new EmployeeSearchResult
                    {
                        EmployeeId = item.EmployeeId,
                        Active = item.Active,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        LastPassword = item.LastName,
                        Password = item.LastName,
                        AccessId = item.AccessId
                    };

                if (!string.IsNullOrEmpty(sm.Email))
                {
                    results = results.Where(x => x.Email.StartsWith(sm.Email));
                }
                if (!string.IsNullOrEmpty(sm.FirstName))
                {
                    results = results.Where(x => x.FirstName.StartsWith(sm.FirstName));
                }
                if (!string.IsNullOrEmpty(sm.LastName))
                {
                    results = results.Where(x => x.LastName.StartsWith(sm.LastName));
                }

                if (sm.AccessId!=0)
                {
                    results = results.Where(x => x.AccessId == sm.AccessId);
                }
                recordCount = results.Count();
                return new EmployeeComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new EmployeeComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
