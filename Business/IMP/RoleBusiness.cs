using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Role;
using DomainModel.Models;

namespace Business.IMP
{
    public class RoleBusiness:IRoleBusiness
    {
        private readonly IRoleRepository repository;

        public RoleBusiness(IRoleRepository repository)
        {
            this.repository = repository;
        }
        private Role ToModel(RoleAddEditModel addEditModel)
        {
            Role role = new Role
            {
               RoleId = addEditModel.RoleId,
               RoleName = addEditModel.RoleName,
               
            };
            return role;

        }

        private RoleAddEditModel ToAddEditModel(Role toModel)
        {
            var role = new RoleAddEditModel
            {
                RoleId = toModel.RoleId,
                RoleName = toModel.RoleName
            };
            return role;
        }
        public OperationResult Delete(int id)
        {
            return repository.Delete(id);
        }

        public OperationResult Update(RoleAddEditModel current)
        {
            return repository.Update(ToModel(current));
        }

        public OperationResult AddNew(RoleAddEditModel current)
        {
            return repository.Add(ToModel(current));
        }

        public RoleAddEditModel Get(int id)
        {
            return ToAddEditModel(repository.Get(id));
        }

        public List<Role> GetAll()
        {
            return repository.GetAll();
        }

        
    }
}
