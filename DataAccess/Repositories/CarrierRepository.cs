using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Address;
using DomainModel.DTO.Carrier;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CarrierRepository:ICarrierRepository
    {
        private readonly ShikaShopContext db;

        public CarrierRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Carrier model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                db.Carriers.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Carrier Success", model.CarrierId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Carrier Failed in Repository =" + ex.Message, model.CarrierId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Carrier",id);
            try
            {
                var carrier = db.Carriers.FirstOrDefault(x => x.CarrierId == id);
                db.Carriers.Remove(carrier);
                db.SaveChanges();
                return op.Succeed("Delete Carrier Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Carrier failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Carrier model)
        {
            OperationResult op = new OperationResult("Update", model.CarrierId);
            try
            {
                db.Carriers.Attach(model);
                db.Entry<Carrier>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Carrier success", model.CarrierId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update This carrier failed in repository = " + ex.Message, model.CarrierId);
            }
        }

        public Carrier Get(int id)
        {
            return db.Carriers.FirstOrDefault(x => x.CarrierId == id);
        }

        public List<Carrier> GetAll()
        {
            return db.Carriers.ToList();
        }

        public CarrierComplexResults Search(CarrierSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Carriers
                              select new CarrierSearchResult
                              {

                                  CarrierId = item.CarrierId,
                                  Active = item.Active,
                                  CarrierName = item.CarrierName,
                                  LocationId = item.LocationId,
                                  Phone = item.Phone,
                                  Url = item.Url,
                              };
                if (!string.IsNullOrEmpty(sm.CarrierName))
                {
                    results = results.Where(x => x.CarrierName.StartsWith(sm.CarrierName));
                }
                if (!string.IsNullOrEmpty(sm.Phone))
                {
                    results = results.Where(x => x.Phone == sm.Phone);
                }
                if (!string.IsNullOrEmpty(sm.Active))
                {
                    results = results.Where(x => x.Active == sm.Active);
                }
                recordCount = results.Count();
                return new CarrierComplexResults
                {
                    Errors = null,
                    MainResults = results.OrderByDescending(x=>x.CarrierId).ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new CarrierComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }


    }
}
