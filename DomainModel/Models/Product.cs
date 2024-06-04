using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public bool OnSale { get; set; }
        public int Quantity { get; set; }
        public int CurrencyId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal ByPrice { get; set; }
        public DateTime AddDate { get; set; }
        public Currency Currency { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductDiscount> ProductDiscounts { get; set; }
        public List<ProductCart> ProductCarts { get; set; }
        public List<ProductOrderReturn> ProductOrderReturns { get; set; }
        public List<Image> Images { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }
        public List<Comment> Comments { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }

        public Product()
        {
            this.ProductCarts = new List<ProductCart>();
            this.ProductOrderReturns =  new List<ProductOrderReturn>();
            this.ProductCategories= new List<ProductCategory>();
            this.ProductDiscounts= new List<ProductDiscount>();
            this.Images=new List<Image>();
            this.ProductFeatures= new List<ProductFeature>();
            this.ProductSuppliers= new List<ProductSupplier>();
            this.OrderProducts = new List<OrderProduct>();
        }

    }
}
