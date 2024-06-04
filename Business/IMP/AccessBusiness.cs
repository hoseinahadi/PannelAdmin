using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Access;
using DomainModel.Models;
using Framework.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Business.IMP
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class AccessBusiness:IAccessBusiness
    {
        private readonly IAccessRepository repo;

        public AccessBusiness(IAccessRepository repo)
        {
            this.repo = repo;
        }

        private Access ToModel(AccessAddOrEditModel addOrEdit)
        {
            return new Access
            {
                AccessId = addOrEdit.AccessId,
                AccessLevel = addOrEdit.AccessLevel,
                Employees = addOrEdit.Employees,
                
            };
        }
        private AccessAddOrEditModel ToAddEditModel(Access model)
        {
            return new AccessAddOrEditModel
            {
                AccessId = model.AccessId,
                AccessLevel = model.AccessLevel,
                Employees = model.Employees,
            };
        }
        public OperationResult Add(AccessAddOrEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(AccessAddOrEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public AccessAddOrEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Access> GetAll()
        {
            return repo.GetAll();
        }

        public bool HasRelatedEmployee(int Id)
        {
            return repo.HasRelatedEmployee(Id);
        }

        public bool HasDuplicateAccess(string name)
        {
            return repo.HasDuplicateAccess(name);
        }

        public AccessComplexResult Search(AccessSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
