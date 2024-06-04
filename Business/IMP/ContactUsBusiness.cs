using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Connection;
using DomainModel.DTO.ContactUs;
using DomainModel.Models;

namespace Business.IMP
{
    public class ContactUsBusiness:IContactUsBusiness
    {
        private readonly IContactUsRepository repo;

        public ContactUsBusiness(IContactUsRepository repo)
        {
            this.repo = repo;
        }
        private ContactUs ToModel(ContactUsAddEditModel addOrEdit)
        {
            return new ContactUs
            {
                ContactUsId = addOrEdit.ContactUsId,
                Phone = addOrEdit.Phone,
                Description = addOrEdit.Description,
                Email = addOrEdit.Email,
                

            };
        }
        private ContactUsAddEditModel ToAddEditModel(ContactUs model)
        {
            return new ContactUsAddEditModel
            {
                ContactUsId = model.ContactUsId,
                Phone = model.Phone,
                Description = model.Description,
                Email = model.Email,
            };
        }
        public OperationResult Add(ContactUsAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(ContactUsAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public ContactUsAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<ContactUs> GetAll()
        {
            return repo.GetAll();
        }

        public ContactUsComplexResults Search(ContactUsSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
