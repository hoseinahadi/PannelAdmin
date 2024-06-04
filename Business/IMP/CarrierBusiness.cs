using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Address;
using DomainModel.DTO.Carrier;
using DomainModel.Models;

namespace Business.IMP
{
    public class CarrierBusiness:ICarrierBusiness
    {
        private readonly ICarrierRepository repo;

        public CarrierBusiness(ICarrierRepository repo)
        {
            this.repo = repo;
        }
        private Carrier ToModel(CarrierAddEditModel addOrEdit)
        {
            return new Carrier
            {
                LocationId = addOrEdit.LocationId,
                Active = addOrEdit.Active,
                CarrierId = addOrEdit.CarrierId,
                CarrierName = addOrEdit.CarrierName,
                Phone = addOrEdit.Phone,
                Url = addOrEdit.Url,
                
            };
        }
        private CarrierAddEditModel ToAddEditModel(Carrier model)
        {
            return new CarrierAddEditModel
            {
                LocationId = model.LocationId,
                Active = model.Active,
                CarrierId = model.CarrierId,
                CarrierName = model.CarrierName,
                Phone = model.Phone,
                Url = model.Url,
                
            };
        }
        public OperationResult Add(CarrierAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(CarrierAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);

        }

        public CarrierAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Carrier> GetAll()
        {
            return repo.GetAll();
        }

        public CarrierComplexResults Search(CarrierSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
