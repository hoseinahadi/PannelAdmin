using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Image;
using DomainModel.DTO.Location;
using DomainModel.Models;

namespace Business.IMP
{
    public class LocationBusiness:ILocationBusiness
    {
        private readonly ILocationRepository repo;

        public LocationBusiness(ILocationRepository repo)
        {
            this.repo = repo;
        }
        private Location ToModel(LocationAddEditModel addOrEdit)
        {
            return new Location
            {
                
                LocationId = addOrEdit.LocationId,
                Url = addOrEdit.Url,
                
            };
        }
        private LocationAddEditModel ToAddEditModel(Location model)
        {
            return new LocationAddEditModel
            {
                
                LocationId = model.LocationId,
                Url = model.Url,
            };
        }
        public OperationResult Add(LocationAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(LocationAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public LocationAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Location> GetAll()
        {
            return repo.GetAll();
        }
    }
}
