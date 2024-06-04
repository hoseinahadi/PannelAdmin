using DomainModel.Assist;
using DomainModel.DTO.Access;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IAccessBusiness
    {
        OperationResult Add(AccessAddOrEditModel model);
        OperationResult Update(AccessAddOrEditModel model);
        OperationResult Delete(int id);
        AccessAddOrEditModel Get(int id);
        List<Access> GetAll();
        AccessComplexResult Search(AccessSearchModel sm, out int recordCount);
        bool HasRelatedEmployee(int Id);
        bool HasDuplicateAccess(string name);

    }
}
