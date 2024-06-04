using DomainModel.Assist;
using DomainModel.DTO.Image;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface IImageBusiness
    {
        OperationResult Add(ImageAddOrEditModel model);
        OperationResult Update(ImageAddOrEditModel model);
        OperationResult Delete(int id);
        ImageAddOrEditModel Get(int id);
        List<Image> GetAll();
        ImageComplexResults Search(ImageSearchModel sm, out int recordCount);
    }
}
