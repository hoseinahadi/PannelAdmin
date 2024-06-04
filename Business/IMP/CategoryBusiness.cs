using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Carrier;
using DomainModel.DTO.Cart;
using DomainModel.DTO.Category;
using DomainModel.Models;

namespace Business.IMP
{
    public class CategoryBusiness:ICategoryBusiness
    {
        private readonly ICategoryRepository repo;
        private readonly IProductRepository Productrepo;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ICategoryDiscountRepository _categoryDiscountRepository;
        private readonly ICategoryFeatureRepository _categoryFeatureRepository;

        public CategoryBusiness(ICategoryRepository repo, IProductRepository productrepo, IProductCategoryRepository productCategoryRepository, ICategoryDiscountRepository categoryDiscountRepository, ICategoryFeatureRepository categoryFeatureRepository)
        {
            this.repo = repo;
            Productrepo = productrepo;
            _productCategoryRepository = productCategoryRepository;
            _categoryDiscountRepository = categoryDiscountRepository;
            _categoryFeatureRepository = categoryFeatureRepository;
        }
        private Category ToModel(CategoryAddOrEditModel addOrEdit)
        {
            return new Category
            {
                CategoryDescription = addOrEdit.CategoryDescription,
                CategoryName = addOrEdit.CategoryName,
                CategoryId = addOrEdit.CategoryId,
                Depth = addOrEdit.Depth,
                Lineage = addOrEdit.Lineage,
                ParentId = addOrEdit.ParentId,
                ProductCount = addOrEdit.ProductCount,
            };
        }
        private CategoryAddOrEditModel ToAddEditModel(Category model)
        {
            return new CategoryAddOrEditModel
            {
                CategoryDescription = model.CategoryDescription,
                CategoryName = model.CategoryName,
                CategoryId = model.CategoryId,
                Depth = model.Depth,
                Lineage = model.Lineage,
                ParentId = model.ParentId??0,
                
                
                ProductCount = model.ProductCount,

            };
        }
        public OperationResult Add(CategoryAddOrEditModel model)
        {
            OperationResult op = new OperationResult("AddNew",model.CategoryId);
            if (DuplicateName(model.CategoryName,model.CategoryId))
            {
                return op.Failed("This name fot other category", model.CategoryId);
            }
            if (model.ParentId != 0)
            {
                var parent = repo.Get(model.ParentId.Value);
                
                var depth = parent.Depth + 1;
                var earlyModel = ToModel(model);
                earlyModel.Depth = depth;
                //Category cat = toCategory(Current);
                //cat.depth = depth;
                //cat.lineage = lineage;
                earlyModel.Lineage = "";
                var result=  repo.Add(earlyModel);
                var lineage = parent.Lineage+","+ result.RecordId + ",";
                earlyModel.Lineage = lineage;
                var q = repo.Update(earlyModel);
                return q;

            }
            else
            {
                
                var depth = 1;
                var earlyModel = ToModel(model);
                earlyModel.ParentId = null;
                earlyModel.Depth = depth;
                //category cat  =  toCategory(Current);
                //cat.depth=depth;
                //cat.lineage=lineage;
                earlyModel.Lineage = "";
                var results = repo.Add(earlyModel);
                var lineage = results.RecordId + ",";
                earlyModel.Lineage = lineage;
                earlyModel.CategoryId = results.RecordId;
                var q = repo.Update(earlyModel);
                return q;
            }
        }

        public OperationResult Update(CategoryAddOrEditModel model)
        {
            OperationResult op = new OperationResult("Update", model.CategoryId);
            
            
            if (DuplicateName(model.CategoryName, model.CategoryId))
            {
                return op.Failed("This name fot other category", model.CategoryId);
            }
            if (model.ParentId!=0)
            {
                var parent = repo.Get(model.ParentId.Value);
                var lineage = parent.Lineage+","+model.CategoryId+",";
                var depth = parent.Depth+1;
                var category = ToModel(model);
                category.Lineage = lineage;
                category.Depth = depth;
                //category cat  =  toCategory(Current);
                //cat.depth=depth;
                //cat.lineage=lineage;
                return repo.Update(category);


            }
            else
            {
                var lineage = model.CategoryId + ",";
                var depth = 1;
                var category = ToModel(model);
                category.Lineage = lineage;
                category.Depth = depth;
                //category cat  =  toCategory(Current);
                //cat.depth=depth;
                //cat.lineage=lineage;
                return repo.Update(category);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", id);
            var result = repo.Get(id);
            if (repo.HasChildren(id))
            {
                return op.Failed("This category has related category", id);
            }
            if (repo.HasProduct(id))
            {
                return op.Failed("This category has related Product", id);
            }
            return repo.Delete(id);
        }

        public CategoryAddOrEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Category> GetAll()
        {
            return repo.GetAll();
        }

        public CategoryComplexResult Search(CategorySearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }

        public bool HasCategory(string name)
        {
            return repo.HasCategory(name);
        }

        public CategoryComplexResult GetParent(int id)
        {
            return repo.GetParent(id);
        }

        public CategoryComplexResult GetParents(int id)
        {
            return repo.GetParents(id);
        }

        public CategoryComplexResult GetChildren(int id)
        {
            return repo.GetChildren(id);
        }

        public bool HasChildren(int id)
        {
            return repo.HasChildren(id);
        }

        public bool HasProduct(int id)
        {
            return repo.HasProduct(id);
        }

        public bool DuplicateName(string name)
        {
            return repo.DuplicateName(name);
        }

        public bool DuplicateName(string name, int id)
        {
            return repo.DuplicateName(name, id);
        }
    }
}
