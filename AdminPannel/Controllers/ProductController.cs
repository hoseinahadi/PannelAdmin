using BusinessServices.Services;
using DomainModel.DTO.Product;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminPannel.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBusiness _productBusiness;
        private readonly ICurrencyBusiness _currencyBusiness;
        private readonly ICategoryBusiness _categoryBusiness;

        public ProductController(IProductBusiness productBusiness, ICurrencyBusiness currencyBusiness, ICategoryBusiness categoryBusiness)
        {
            _productBusiness = productBusiness;
            _currencyBusiness = currencyBusiness;
            _categoryBusiness = categoryBusiness;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllInOrder()
        {
            var product = _productBusiness.GetAll();
            return View(product);
        }



        [HttpGet]
        public IActionResult ViewComponents()
        {
            return ViewComponent("Product");
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result= _productBusiness.Delete(id);
            return Json(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Currency> List = _currencyBusiness.GetAll();
            var cur = new Currency
            {
                CurrencyId = 0,
                CurrencyName = " واحد پولی را وارد کنید "
                
            };
            List.Add(cur);
            ViewBag.currency = new SelectList(List, "CurrencyId", "CurrencyName");
            List<Category> categoryList = _categoryBusiness.GetAll();
            var cat = new Category
            {
                CategoryId = 0,
                CategoryName = " دسته بندی را وارد کنید "
            };
            categoryList.Add(cat);
            ViewBag.category = new SelectList(categoryList, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductAddEditModel model)
        {
            if (model.Quantity!=0)
            {
                model.State = " موجود ";
            }
            model.AddDate= DateTime.Now;
            var result = _productBusiness.Add(model);
            return Json(result);
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            List<Currency> List = _currencyBusiness.GetAll();
            var cur = new Currency
            {
                CurrencyId = 0,
                CurrencyName = " واحد پولی را وارد کنید "

            };
            List.Add(cur);
            ViewBag.currency = new SelectList(List, "CurrencyId", "CurrencyName");
            List<Category> categoryList = _categoryBusiness.GetAll();
            var cat = new Category
            {
                CategoryId = 0,
                CategoryName = " دسته بندی را وارد کنید "
            };
            categoryList.Add(cat);
            ViewBag.category = new SelectList(categoryList, "CategoryId", "CategoryName");
            var result = _productBusiness.Get(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(ProductAddEditModel model)
        {
            var result = _productBusiness.Update(model);
            return Json(result);
        }



        [HttpPost]
        public IActionResult Details(int id)
        {
            var result = _productBusiness.Get(id);
            return Json(result);
        }
    }
}
