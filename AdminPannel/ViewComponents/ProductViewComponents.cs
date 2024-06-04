using BusinessServices.Services;
using DomainModel.DTO.Image;
using DomainModel.DTO.Message;
using DomainModel.DTO.Order;
using DomainModel.DTO.Product;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    [ViewComponent(Name = "Product")]
    public class ProductViewComponents : ViewComponent
    {
        private readonly IProductBusiness _productBusiness;
        private readonly ICurrencyBusiness _currencyBusiness;
        private readonly IImageBusiness _imageBusiness;

        public ProductViewComponents(IProductBusiness productBusiness, ICurrencyBusiness currencyBusiness, IImageBusiness imageBusiness)
        {
            _productBusiness = productBusiness;
            _currencyBusiness = currencyBusiness;
            _imageBusiness = imageBusiness;
        }
        public IViewComponentResult Invoke()
        {

            var listProductSearchResult = new List<ProductSearchResult>();
            var imageSearchModel = new ImageSearchModel();
            var result = _productBusiness.GetAll();

            foreach (var item in result)
            {
                var x = 10;
                imageSearchModel.ProductName=item.ProductName;
                var currencyAddEditModel = _currencyBusiness.Get(item.CurrencyId);
                var currency = new Currency
                {
                    CurrencyName = currencyAddEditModel.CurrencyName,
                    CurrencyId = currencyAddEditModel.CurrencyId,
                };
                var image = _imageBusiness.Search(imageSearchModel,out x).MainResults;
                var productSearchResult = new ProductSearchResult
                {
                    State = item.State,
                    AddDate = item.AddDate,
                    CurrencyId = item.CurrencyId,
                    ByPrice = item.ByPrice,
                    Description = item.Description,
                    OnSale = item.OnSale,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    WholeSalePrice = item.WholeSalePrice,
                    Currency = currency,
                    ImageSearchResults = image
                };
            }
            return View(result);
        }
    }
}
