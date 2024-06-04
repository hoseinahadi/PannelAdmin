using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.OrderReturn;
using DomainModel.DTO.Product;
using DomainModel.Models;

namespace Business.IMP
{
    public class ProductBusiness:IProductBusiness
    {
        private readonly IProductRepository repo;

        public ProductBusiness(IProductRepository repo)
        {
            this.repo = repo;
        }
        private Product ToModel(ProductAddEditModel addOrEdit)
        {
            return new Product
            {
                CurrencyId = addOrEdit.CurrencyId,
                State = addOrEdit.State,
                AddDate = addOrEdit.AddDate,
                ByPrice = addOrEdit.ByPrice,
                Description = addOrEdit.Description,
                OnSale = addOrEdit.OnSale,
                Price = addOrEdit.Price,
                ProductId = addOrEdit.ProductId,
                ProductName = addOrEdit.ProductName,
                Quantity = addOrEdit.Quantity,
                WholeSalePrice = addOrEdit.WholeSalePrice,

            };
        }
        private ProductAddEditModel ToAddEditModel(Product model)
        {
            return new ProductAddEditModel
            {
                CurrencyId = model.CurrencyId,
                State = model.State,
                AddDate = model.AddDate,
                ByPrice = model.ByPrice,
                Description = model.Description,
                OnSale = model.OnSale,
                Price = model.Price,
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                Quantity = model.Quantity,
                WholeSalePrice = model.WholeSalePrice,


            };
        }
        public OperationResult Add(ProductAddEditModel model)
        {
            return repo.Add(ToModel(model));
        }

        public OperationResult Update(ProductAddEditModel model)
        {
            return repo.Update(ToModel(model));
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public ProductAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Product> GetAll()
        {
            return repo.GetAll();
        }

        public ProductComplexResults Search(ProductSearchModel sm, out int recordCount)
        {
            return repo.Search(sm, out recordCount);
        }
    }
}
