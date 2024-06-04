using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Product
{
    public class ProductSearchModel : PageModel
    {
        public bool OnSale { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal ByPrice { get; set; }
        public DateTime AddDate { get; set; }
    }
}
