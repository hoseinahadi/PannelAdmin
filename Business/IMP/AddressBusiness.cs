using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Access;
using DomainModel.DTO.Address;
using DomainModel.Models;

namespace Business.IMP
{
    public class AddressBusiness:IAddressBusiness
    {
        private readonly IAddressRepository repo;

        public AddressBusiness(IAddressRepository repo)
        {
            this.repo = repo;
        }
        private Address ToModel(AddressAddOrEditModel addOrEdit)
        {
            if (addOrEdit != null)
            {
                return new Address
                {
                    State = addOrEdit.State,
                    UserId = addOrEdit.UserId,
                    AddressId = addOrEdit.AddressId,
                    City = addOrEdit.City,
                    CompanyName = addOrEdit.CompanyName,
                    
                    CountryId = addOrEdit.CountryId,
                    EmployeeId = addOrEdit.EmployeeId,
                    MobileNumber = addOrEdit.MobileNumber,
                    Note = addOrEdit.Note,
                    PhoneNumber = addOrEdit.PhoneNumber,
                    PostCode = addOrEdit.PostCode,
                    SupplierId = addOrEdit.SupplierId,
                    Street = addOrEdit.Street,
                    plaq = addOrEdit.plaq,
                };
            }

            return null;
        }
        private AddressAddOrEditModel ToAddEditModel(Address model)
        {
            if (model !=null)
            {
                return new AddressAddOrEditModel
                {
                    State = model.State,
                    UserId = model.UserId,
                    AddressId = model.AddressId,
                    City = model.City,
                    CompanyName = model.CompanyName,
                    
                    CountryId = model.CountryId,
                    EmployeeId = model.EmployeeId,
                    MobileNumber = model.MobileNumber,
                    Note = model.Note,
                    PhoneNumber = model.PhoneNumber,
                    PostCode = model.PostCode,
                    SupplierId = model.SupplierId,
                    Street = model.Street,
                    plaq = model.plaq,


                };
            }

            return null;

        }
        public OperationResult Add(AddressAddOrEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(AddressAddOrEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public AddressAddOrEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Address> GetAll()
        {
            if (repo.GetAll().Count!=0)
            {
                return repo.GetAll();
            }
            return new List<Address>();
            
        }

        public AddressComplexResult Search(AddressSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
