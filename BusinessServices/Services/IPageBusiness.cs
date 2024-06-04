using DomainModel.Assist;
using DomainModel.DTO.Page;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IPageBusiness
    {
        OperationResult Add(PageAddEditModel model);
        OperationResult Update(PageAddEditModel model);
        OperationResult Delete(int id);
        PageAddEditModel Get(int id);
        List<Page> GetAll();

    }
}
