using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Feature;
using DomainModel.DTO.Gender;
using DomainModel.Models;

namespace Business.IMP
{
    public class GenderBusiness:IGenderBusiness
    {
        private readonly IGenderRepository repo;

        public GenderBusiness(IGenderRepository repo)
        {
            this.repo = repo;
        }
        private Gender ToModel(GenderAddEditModel addOrEdit)
        {
            return new Gender
            {
                GenderId = addOrEdit.GenderId,
                GenderName = addOrEdit.GenderName,
                
                
            };
        }
        private GenderAddEditModel ToAddEditModel(Gender model)
        {
            return new GenderAddEditModel
            {
                GenderId = model.GenderId,
                GenderName = model.GenderName,
                
            };
        }
        public OperationResult Add(GenderAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(GenderAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public GenderAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Gender> GetAll()
        {
            return repo.GetAll();
        }
    }
}
