using BusinessServices.Services;
using DomainModel.DTO.Image;
using DomainModel.DTO.Message;
using DomainModel.DTO.Order;
using DomainModel.DTO.Product;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    [ViewComponent(Name = "Address")]
    public class AddressViewComponents : ViewComponent
    {
        private readonly IAddressBusiness _addressBusiness;

        public AddressViewComponents(IAddressBusiness addressBusiness)
        {
            _addressBusiness = addressBusiness;
        }
        public IViewComponentResult Invoke()
        {
            var address = _addressBusiness.GetAll();
            
            return View(address);
        }
    }
}
