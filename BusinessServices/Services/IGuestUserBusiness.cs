using DomainModel.Assist;
using DomainModel.DTO.GuestUser;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IGuestUserBusiness
    {
        OperationResult Add(GuestUserAddEditModel model);
        OperationResult Update(GuestUserAddEditModel model);
        OperationResult Delete(int id);
        GuestUserAddEditModel Get(int id);
        List<GuestUser> GetAll();
        GuestUserComplexResults Search(GuestUserSearchModel sm, out int recordCount);
    }
}
