using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Currency;
using DomainModel.DTO.Delivery;
using DomainModel.Models;

namespace Business.IMP
{
    public class DeliveryBusiness:IDeliveryBusiness
    {
        private readonly IDeliveryRepository repo;

        public DeliveryBusiness(IDeliveryRepository repo)
        {
            this.repo = repo;
        }
        private Delivery ToModel(DeliveryAddOrEditModel addOrEdit)
        {
            return new Delivery
            {
                CurrencyId = addOrEdit.CurrencyId,
                DeliveryName = addOrEdit.DeliveryName,
                CarrierId = addOrEdit.CarrierId,
                DeliveryId = addOrEdit.DeliveryId,
                Price = addOrEdit.Price,

                

            };
        }
        private DeliveryAddOrEditModel ToAddEditModel(Delivery model)
        {
            return new DeliveryAddOrEditModel
            {
                CurrencyId = model.CurrencyId,
                DeliveryName = model.DeliveryName,
                CarrierId = model.CarrierId,
                DeliveryId = model.DeliveryId,
                Price = model.Price,

            };
        }

        public OperationResult Add(DeliveryAddOrEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(DeliveryAddOrEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public DeliveryAddOrEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Delivery> GetAll()
        {
            return repo.GetAll();
        }

        public DeliveryComplexResults Search(DeliverySearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
