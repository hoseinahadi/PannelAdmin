using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Cart;
using DomainModel.DTO.Connection;
using DomainModel.Models;

namespace Business.IMP
{
    public class ConnectionBusiness:IConnectionBusiness
    {
        private readonly IConnectionRepository repoo;

        public ConnectionBusiness(IConnectionRepository repoo)
        {
            this.repoo = repoo;
        }
        private Connection ToModel(ConnectionAddOrEditModel addOrEdit)
        {
            return new Connection
            {
                PageId = addOrEdit.PageId,
                ConnectionId = addOrEdit.ConnectionId,
                EndDate = addOrEdit.EndDate,
                StartDate = addOrEdit.StartDate,
                
                

            };
        }
        private ConnectionAddOrEditModel ToAddEditModel(Connection model)
        {
            return new ConnectionAddOrEditModel
            {
                PageId = model.PageId,
                ConnectionId = model.ConnectionId,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                
                
            };
        }
        public OperationResult Add(ConnectionAddOrEditModel model)
        {
            return repoo.Add(ToModel(model));
        }

        public OperationResult Update(ConnectionAddOrEditModel model)
        {
            return repoo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repoo.Delete(id);
        }

        public ConnectionAddOrEditModel Get(int id)
        {
            return ToAddEditModel(repoo.Get(id));
        }

        public List<Connection> GetAll()
        {
            return repoo.GetAll();
        }

        public ConnectionComplexResult Search(ConnectionSearchModel sm, out int recordCount)
        {
            return repoo.Search(sm, out recordCount);
        }
    }
}
