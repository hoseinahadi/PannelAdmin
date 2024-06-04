using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.DTO.Image;

namespace DomainModel.DTO.Product
{
    public class ProductSearchResult
    {
        public int ProductId { get; set; }
        public bool OnSale { get; set; }
        public int Quantity { get; set; }
        public int CurrencyId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal ByPrice { get; set; }
        public DateTime AddDate { get; set; }

        public Models.Currency Currency { get; set; }
        public List<Models.Category> ProductCategories { get; set; }
        public List<Models.Discount> ProductDiscounts { get; set; }
        public List<ImageSearchResult> ImageSearchResults { get; set; }
        public List<Models.Feature> ProductFeatures { get; set; }
        public List<Models.Supplier> ProductSuppliers { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
