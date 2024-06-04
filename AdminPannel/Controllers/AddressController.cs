using BusinessServices.Services;
using DomainModel.DTO.Address;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.Controllers
{
    
    public class AddressController : Controller
    {
        private readonly IAddressBusiness _addressBusiness;

        public AddressController(IAddressBusiness addressBusiness)
        {
            _addressBusiness = addressBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _addressBusiness.Delete(id);
            return Json(result);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _addressBusiness.Get(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(AddressAddOrEditModel model)
        {
            var result = _addressBusiness.Update(model);
            return Json(result);
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddressAddOrEditModel model)
        {
            var result = _addressBusiness.Add(model);
            return Json(result);
        }



        [HttpGet]
        public IActionResult ViewComponents()
        {
            return ViewComponent("Address");
        }
    }
}
