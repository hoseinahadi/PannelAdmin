using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int? ParentId { get; set; }
        public List<Category>? Children { get; set; }
        public Category? Parent { get; set; }
        public string Lineage  { get; set; }
        public int ProductCount { get; set; }
        public int Depth { get; set; }
        public List<CategoryDiscount> CategoryDiscounts { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<CategoryFeature> CategoryFeatures { get; set; }

        public Category()
        {
            this.Children=new List<Category>();
            this.CategoryDiscounts=new List<CategoryDiscount>();
            this.ProductCategories=new List<ProductCategory>();
            this.CategoryFeatures=new List<CategoryFeature>();
        }

    }
}
