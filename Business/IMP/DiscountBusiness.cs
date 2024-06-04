using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Delivery;
using DomainModel.DTO.Discount;
using DomainModel.Models;

namespace Business.IMP
{
    public class DiscountBusiness:IDiscountBusiness
    {
        private readonly IDiscountRepository repo;
        private readonly ICategoryDiscountRepository categoryDiscountRepository;

        public DiscountBusiness(IDiscountRepository repo, ICategoryDiscountRepository categoryDiscountRepository)
        {
            this.repo = repo;
            this.categoryDiscountRepository = categoryDiscountRepository;
        }
        private Discount ToModel(DiscountAddOrEditModel addOrEdit)
        {
            return new Discount
            {
                Name = addOrEdit.Name,
                DiscountId = addOrEdit.DiscountId,
                Percent = addOrEdit.Percent,

                
            };
        }
        private DiscountAddOrEditModel ToAddEditModel(Discount model)
        {
            return new DiscountAddOrEditModel
            {
                Name = model.Name,
                DiscountId = model.DiscountId,
                Percent = model.Percent,


            };
        }
        public OperationResult Add(DiscountAddOrEditModel model)
        {


            return repo.Add(ToModel(model));

        }

        public OperationResult Update(DiscountAddOrEditModel model)
        {
            OperationResult op = new OperationResult("Update");
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public DiscountAddOrEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Discount> GetAll()
        {
            return repo.GetAll();
        }

        public DiscountComplexResults Search(DiscountSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
