using DomainModel.Assist;
using DomainModel.DTO.ContactUs;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IContactUsBusiness
    {
        OperationResult Add(ContactUsAddEditModel model);
        OperationResult Update(ContactUsAddEditModel model);
        OperationResult Delete(int id);
        ContactUsAddEditModel Get(int id);
        List<ContactUs> GetAll();
        ContactUsComplexResults Search(ContactUsSearchModel sm, out int recordCount);
    }
}
