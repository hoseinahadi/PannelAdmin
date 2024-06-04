using BusinessServices.Services;
using DomainModel.DTO.Image;
using DomainModel.DTO.Message;
using DomainModel.DTO.Order;
using DomainModel.DTO.Product;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    [ViewComponent(Name = "Image")]
    public class ImageViewComponents : ViewComponent
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IUserBusiness _userBusiness;
        private readonly IImageBusiness _imageBusiness;

        public ImageViewComponents(IProductBusiness productBusiness, IUserBusiness userBusiness, IImageBusiness imageBusiness)
        {
            _productBusiness = productBusiness;
            _userBusiness = userBusiness;
            _imageBusiness = imageBusiness;
        }
        public IViewComponentResult Invoke()
        {
            var images = _imageBusiness.GetAll();
            
            return View(images);
        }
    }
}
