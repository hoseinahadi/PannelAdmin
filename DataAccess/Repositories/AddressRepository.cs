using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;

using DomainModel.Assist;
using DomainModel.DTO.Address;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AddressRepository:IAddressRepository
    {
        private readonly ShikaShopContext db;

        public AddressRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Address model)
        {
            OperationResult op = new OperationResult("Add New");

            try
            {

                db.Addresses.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New Address Success", model.AddressId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add new Address Failed in repository = " +ex.Message, model.AddressId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Address", id);
            try
            {
                var result = db.Addresses.FirstOrDefault(x => x.AddressId == id);
                db.Addresses.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Address Success", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Address Failed in Repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Address model)
        {
            OperationResult op = new OperationResult("Update Address", model.AddressId);
            try
            {
                db.Addresses.Attach(model);
                db.Entry<Address>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Address Success", model.AddressId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Address Failed in Repository =" + ex.Message, model.AddressId);
            }
        }

        public Address Get(int id)
        {
            var address =  db.Addresses.FirstOrDefault(x => x.AddressId == id);
            return address;
        }

        public List<Address> GetAll()
        {
            return db.Addresses.ToList();
        }

        public AddressComplexResult Search(AddressSearchModel sm, out int recordCount)
        {
            List<string> Erorr = new List<string>();
            recordCount = 0;
            try
            {
                var address = from item in db.Addresses
                    select new AddressSearchResults
                    {
                        AddressId = item.AddressId,
                        Street = item.Street,
                        MobileNumber = item.MobileNumber,
                        PhoneNumber = item.PhoneNumber,
                        PostCode = item.PostCode,
                        City = item.City,
                        Country = item.Country,
                        State = item.State,
                        plaq = item.plaq,
                        CompanyName = item.CompanyName,
                        CountryId = item.CountryId,
                        EmployeeId = item.EmployeeId,
                        Note = item.Note,
                        SupplierId = item.SupplierId,
                        UserId = item.UserId,
                    };
                
                if (!string.IsNullOrEmpty(sm.City))
                {
                    address = address.Where(x => x.City.StartsWith(sm.City));
                }
                if (!string.IsNullOrEmpty(sm.CompanyName))
                {
                    address = address.Where(x => x.CompanyName.StartsWith(sm.CompanyName));
                }
                if (!string.IsNullOrEmpty(sm.Country))
                {
                    address = address.Where(x => x.Country.StartsWith(sm.Country));
                }
                if (!string.IsNullOrEmpty(sm.MobileNumber))
                {
                    address = address.Where(x => x.MobileNumber.StartsWith(sm.MobileNumber));
                }
                if (!string.IsNullOrEmpty(sm.PhoneNumber))
                {
                    address = address.Where(x => x.PhoneNumber.StartsWith(sm.PhoneNumber));
                }
                if (!string.IsNullOrEmpty(sm.PostCode))
                {
                    address = address.Where(x => x.PostCode.StartsWith(sm.PostCode));
                }
                if (!string.IsNullOrEmpty(sm.Street))
                {
                    address = address.Where(x => x.Street.StartsWith(sm.Street));
                }
                if (!string.IsNullOrEmpty(sm.plaq))
                {
                    address = address.Where(x => x.plaq.StartsWith(sm.plaq));
                }
                recordCount =address.Count();
                return new AddressComplexResult
                {
                    Errors = null,
                    MainResults = address.OrderByDescending(x=>x.AddressId).ToList()
                };
            }
            catch (Exception e)
            {
                Erorr.Add(e.Message);
                return new AddressComplexResult
                {
                    Errors = Erorr,
                    MainResults = null
                };
            }

        }


    }
}
