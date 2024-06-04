using DomainModel.Assist;
using DomainModel.DTO.Category;
using DomainModel.Models;

namespace BusinessServices.Services
{
    public interface ICategoryBusiness
    {
        OperationResult Add(CategoryAddOrEditModel model);
        OperationResult Update(CategoryAddOrEditModel model);
        OperationResult Delete(int id);
        CategoryAddOrEditModel Get(int id);
        List<Category> GetAll();
        CategoryComplexResult Search(CategorySearchModel sm, out int recordCount);
        bool HasCategory(string name);
        CategoryComplexResult GetParent(int id);
        CategoryComplexResult GetParents(int id);
        CategoryComplexResult GetChildren(int id);
        bool HasChildren(int id);
        bool HasProduct(int id);
        bool DuplicateName(string name);
        bool DuplicateName(string name, int id);
    }
}
