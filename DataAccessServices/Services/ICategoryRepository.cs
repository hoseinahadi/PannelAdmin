using DataAccessServices.Services.Base;
using DomainModel.DTO.Category;
using DomainModel.Models;

namespace DataAccessServices.Services
{
    public interface ICategoryRepository : IBaseRepositorySearchable<Category, int, CategorySearchModel, CategoryComplexResult>
    {
        bool HasCategory(string name);
        CategoryComplexResult GetParent(int id);
        CategoryComplexResult GetParents(int id);
        CategoryComplexResult GetChildren(int id);
        bool HasProduct(int id);
        bool HasChildren(int id);
        bool DuplicateName(string name);
        bool DuplicateName(string name,int id);

    }
}
