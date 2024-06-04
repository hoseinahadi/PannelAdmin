using Business.IMP;
using BusinessServices.Services;
using DomainModel.DTO.Category;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminPannel.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryBusiness _categoryBusiness;

        public CategoryController(ICategoryBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _categoryBusiness.Delete(id);
            return Json(result);
        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            List<Category> userList = _categoryBusiness.GetAll();
            Category category = new Category
            {
                CategoryName = " دسته بندی انتخاب کنید ",
                CategoryId = 0
            };
            userList.Add(category);
            ViewBag.category = new SelectList(userList, "CategoryId", "CategoryName");
            var result = _categoryBusiness.Get(id);
            return View(result);
        }


        [HttpPost]
        public IActionResult Update(CategoryAddOrEditModel model)
        {
            
            
            var result = _categoryBusiness.Update(model);
            return Json(result);
        }



        [HttpGet]
        public IActionResult Add()
        {
            List<Category> userList = _categoryBusiness.GetAll();
            Category category = new Category
            {
                CategoryName = " دسته بندی انتخاب کنید ",
                CategoryId = 0
            };
            ViewBag.category = new SelectList(userList, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryAddOrEditModel model)
        {
            var result = _categoryBusiness.Add(model);
            return Json(result);
        }



        [HttpGet]
        public IActionResult ViewComponents()
        {
            return ViewComponent("Category");
        }
    }
}
