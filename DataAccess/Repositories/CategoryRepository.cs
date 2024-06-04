using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Category;
using DomainModel.Models;
using DomainModel.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ShikaShopContext db;

        public CategoryRepository(ShikaShopContext db)
        {
            this.db = db;
        }
        public OperationResult Add(Category model)
        {
            OperationResult op = new OperationResult("Add New");
            try
            {
                if (DuplicateName(model.CategoryName))
                {
                    return op.Failed(" this category Has Exist  ", model.CategoryId);
                }
                db.Categories.Add(model);
                db.SaveChanges();
                return op.Succeed("Add New category succeed", model.CategoryId);
            }
            catch (Exception ex)
            {
                return op.Failed("Add New Category failed in repository =" + ex.Message,model.CategoryId);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete ", id);
            try
            {
                var result = db.Categories.FirstOrDefault(x => x.CategoryId == id);
                if (result == null)
                {
                    return op.Failed("this category not found", id);
                }

                db.Categories.Remove(result);
                db.SaveChanges();
                return op.Succeed("Delete Category succeed", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Delete Category failed in repository =" + ex.Message, id);
            }
        }

        public OperationResult Update(Category model)
        {
            OperationResult op = new OperationResult(" Update", model.CategoryId);
            try
            {
                db.Categories.Attach(model);
                db.Entry<Category>(model).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed(" Update Category Succeed ", model.CategoryId);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Category failed in repository =" + ex.Message, model.CategoryId);
            }
        }

        public Category Get(int id)
        {
            var result = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (result!=null)
            {
                return result;
            }
            return null;
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public CategoryComplexResult Search(CategorySearchModel sm, out int recordCount)
        {
            List<string> Error = new List<string>();
            recordCount = 0;
            try
            {
                var result = from item in db.Categories
                    select new CategorySearchResult 
                        {
                            CategoryDescription = item.CategoryDescription,
                            CategoryId = item.CategoryId,
                            CategoryName = item.CategoryName,
                            Parent = item.Parent,
                            Children = item.Children,
                            Depth = item.Depth,
                            Lineage = item.Lineage,
                            ParentId = item.ParentId,
                            ProductCount = item.ProductCount,
                        };
                if (!string.IsNullOrEmpty(sm.CategoryName))
                {
                    result = result.Where(x => x.CategoryName.StartsWith(sm.CategoryName));
                }
                if (!string.IsNullOrEmpty(sm.Lineage))
                {
                    result = result.Where(x => x.Lineage == sm.Lineage);
                }
                if (sm.ParentId != null)
                {
                    result = result.Where(x => x.ParentId == sm.ParentId);
                }

                

                recordCount =result.Count();
                //CategorySearchResult = result.Skip()
                CategoryComplexResult results = new CategoryComplexResult
                {
                    Errors = null,
                    MainResults = result.ToList()
                };
                return results;
            }
            catch (Exception ex)
            {
                Error.Add(ex.Message);
                CategoryComplexResult results = new CategoryComplexResult
                {
                    Errors = Error,
                    MainResults = null
                };
                return results;
            }

        }

        public bool HasCategory(string name)
        {
            return db.Categories.Any(x => x.CategoryName == name);
        }

        public CategoryComplexResult GetParent(int id)
        {
            List<string> Erorr = new List<string>();
            var result =  db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (result !=null)
            {
                var parent = result.Parent; 
                if (parent != null)
                {
                    CategorySearchResult sr = new CategorySearchResult
                    {
                        CategoryName = result.Parent.CategoryName,
                    };
                    List<CategorySearchResult> srlist = new List<CategorySearchResult>();
                    srlist.Add(sr);
                    return new CategoryComplexResult
                    {
                        Errors = null,
                        MainResults = srlist
                    };
                }
                else
                {
                    Erorr.Add("this Category not parent");
                    return new CategoryComplexResult
                    {
                        Errors = Erorr,
                        MainResults = null
                    };
                }
            }
            Erorr.Add("this category not found");
            return new CategoryComplexResult
            {
                Errors = Erorr,
                MainResults = null
            };

        }
        

        public CategoryComplexResult GetParents(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryComplexResult GetChildren(int id)
        {
            List<string> Erorr = new List<string>();
            var result = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (result != null)
            {
                var children = result.Children;
                if (children != null)
                {

                    return new CategoryComplexResult
                    {
                        Errors = null,
                        MainResults = children.Select(x=> new CategorySearchResult
                        {
                            Children = x.Children,
                            CategoryDescription = x.CategoryDescription,
                            CategoryName = x.CategoryName,
                            CategoryId = x.CategoryId,
                            Parent = x.Parent,
                            Lineage = x.Lineage,
                            Depth = x.Depth,
                            ProductCount = x.ProductCount,
                        }).ToList()
                    };
                }
                else
                {
                    Erorr.Add("this Category not children");
                    return new CategoryComplexResult
                    {
                        Errors = Erorr,
                        MainResults = null
                    };
                }
            }
            Erorr.Add("this category not found");
            return new CategoryComplexResult
            {
                Errors = Erorr,
                MainResults = null
            };

        }

        public bool HasProduct(int id)
        {
            return db.CategoryDiscounts.Any(x => x.CategoryId == id);
        }

        public bool HasChildren(int id)
        {
            return db.Categories.Any(x => x.ParentId==id);
        }

        public bool DuplicateName(string name)
        {
            return db.Categories.Any(x => x.CategoryName == name);
        }

        public bool DuplicateName(string name, int id)
        {
            return db.Categories.Any(x => x.CategoryName == name && x.CategoryId!=id);
        }
    }
}
