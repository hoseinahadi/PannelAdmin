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
    public class LocationRepository:ILocationRepository
    {
        private readonly ShikaShopContext db;

        public LocationRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Location model)
        {
            OperationResult op = new OperationResult("Add New Location ");
            try
            {
                db.Locations.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Location succeed", model.LocationId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add new Location failed in repository =" + ex.Message, model.LocationId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete location ", id);
            try
            {
                var result = db.Locations.FirstOrDefault(x => x.LocationId == id);
                if (result!=null)
                {
                    db.Locations.Remove(result);
                    db.SaveChanges();
                    return op.Succeed("Delete location succeed", id);
                }

                return op.Failed("this location not found", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete location failed in repository =" + ex.Message, id);
            }

        }

        public OperationResult Update(Location model)
        {
            OperationResult op = new OperationResult("update", model.LocationId);
            try
            {
                db.Locations.Attach(model);
                db.Entry<Location>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update location succeed", model.LocationId); 
            }
            catch (Exception ex)
            {
                return op.Failed("Update location failed in repository =" + ex.Message, model.LocationId);
            }
        }

        public Location Get(int id)
        {
            var result = db.Locations.FirstOrDefault(x => x.LocationId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<Location> GetAll()
        {
            return db.Locations.ToList();
        }
    }
}
