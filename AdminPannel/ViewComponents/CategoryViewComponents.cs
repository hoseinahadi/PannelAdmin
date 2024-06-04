using BusinessServices.Services;
using DomainModel.DTO.Message;
using DomainModel.DTO.Order;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    [ViewComponent(Name = "Category")]
    public class CategoryViewComponents : ViewComponent
    {
        private readonly ICategoryBusiness _categoryBusiness;

        public CategoryViewComponents(ICategoryBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }


        public IViewComponentResult Invoke()
        {
            var result = _categoryBusiness.GetAll();
            return View(result);
        }
    }
}
