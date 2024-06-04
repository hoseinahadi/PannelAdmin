using DomainModel.Assist;
using DomainModel.DTO.Connection;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IConnectionBusiness
    {
        OperationResult Add(ConnectionAddOrEditModel model);
        OperationResult Update(ConnectionAddOrEditModel model);
        OperationResult Delete(int id);
        ConnectionAddOrEditModel Get(int id);
        List<Connection> GetAll();
        ConnectionComplexResult Search(ConnectionSearchModel sm, out int recordCount);
    }
}
