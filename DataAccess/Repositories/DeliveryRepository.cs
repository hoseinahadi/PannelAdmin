using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Delivery;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class DeliveryRepository:IDeliveryRepository
    {
        private readonly ShikaShopContext db;

        public DeliveryRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Delivery model)
        {
            OperationResult op = new OperationResult("Add New delivery");
            try
            {
                db.Deliveries.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Delivery Succeed", model.DeliveryId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add new Delivery failed in repository =" + ex.Message, model.DeliveryId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete",id);
            try
            {
                var result = db.Deliveries.FirstOrDefault(x => x.DeliveryId == id);
                db.Deliveries.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Delivery succeed", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Delivery failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Delivery model)
        {
            OperationResult op = new OperationResult("Update", model.DeliveryId);
            try
            {
                db.Deliveries.Attach(model);
                db.Entry<Delivery>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Delivery succeed ", model.DeliveryId);

            }
            catch (Exception ex)
            {
                return op.Failed("Update Delivery Failed in repository =" + ex.Message, model.DeliveryId);
            }
        }

        public Delivery Get(int id)
        {
            return db.Deliveries.FirstOrDefault(x => x.DeliveryId == id);
        }

        public List<Delivery> GetAll()
        {
            return db.Deliveries.ToList();
        }

        public DeliveryComplexResults Search(DeliverySearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var results = from item in db.Deliveries
                    select new DeliverySearchResult
                    {
                        CarrierId = item.CarrierId,
                        CurrencyId = item.CurrencyId,
                        Price = item.Price,
                        DeliveryId = item.DeliveryId,
                        DeliveryName = item.DeliveryName,
                    };
                if (!string.IsNullOrEmpty(sm.DeliveryName))
                {
                    results = results.Where(x => x.DeliveryName.StartsWith(sm.DeliveryName));
                }
                recordCount = results.Count();
                return new DeliveryComplexResults
                {
                    Errors = null,
                    MainResults = results.ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new DeliveryComplexResults
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }
        }
    }
}
