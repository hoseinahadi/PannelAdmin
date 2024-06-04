using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Category
{
    public class CategorySearchModel : PageModel
    {
        public string CategoryName { get; set; }
        public int? ParentId { get; set; }
        public int CategoryId { get; set; }
        public string Lineage { get; set; }
        public int ProductCount { get; set; }
        public int Depth { get; set; }
        

    }
}
