using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DomainModel.DTO.Category
{
    public class CategorySearchResult
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int? ParentId { get; set; }
        public List<Models.Category> Children { get; set; }
        public Models.Category Parent { get; set; }
        public string Lineage { get; set; }
        public int ProductCount { get; set; }
        public int Depth { get; set; }
        public List<Models.Product> Products { get; set; }
        
    }
}
