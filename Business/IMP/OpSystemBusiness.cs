using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Message;
using DomainModel.DTO.OpSystem;
using DomainModel.Models;

namespace Business.IMP
{
    public class OpSystemBusiness:IOpSystemBusiness
    {
        private readonly IOpSystemRepository repo;

        public OpSystemBusiness(IOpSystemRepository repo)
        {
            this.repo = repo;
        }
        private OpSystem ToModel(OpSystemAddEditModel addOrEdit)
        {
            return new OpSystem
            {
                OpName = addOrEdit.OpName,
                OpSystemId = addOrEdit.OpSystemId,

            };
        }
        private OpSystemAddEditModel ToAddEditModel(OpSystem model)
        {
            return new OpSystemAddEditModel
            {
                
                OpName = model.OpName,
                OpSystemId = model.OpSystemId,

            };
        }
        public OperationResult Add(OpSystemAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(OpSystemAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public OpSystemAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<OpSystem> GetAll()
        {
            return repo.GetAll();
        }
    }
}
