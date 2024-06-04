using Business.IMP;
using BusinessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Image;
using DomainModel.Models;
using Framework.ImageUtility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace AdminPannel.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageBusiness _imageBusiness;
        private readonly IUserBusiness _userBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly IHostingEnvironment env;

        public ImageController(IImageBusiness imageBusiness, IUserBusiness userBusiness, IProductBusiness productBusiness, IEmployeeBusiness employeeBusiness, IHostingEnvironment env)
        {
            _imageBusiness = imageBusiness;
            _userBusiness = userBusiness;
            _productBusiness = productBusiness;
            _employeeBusiness = employeeBusiness;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            DropDownMenu();
            return View();
        }
        [HttpPost]
        public IActionResult Add(ImageAddOrEditModel model)
        {
            int x = 0;
            
                if (model.ProductId == 0)
                {
                    model.ProductId = null;
                }
                if (model.UserId == 0)
                {
                    model.UserId = null;
                }
                var fileName = System.IO.Path.GetFileName(model.Picture.FileName);
                if (!fileName.IsValidFileName())
                {
                    return Json($" نام فایل{model.Picture.FileName} صحیح نمیباشد ");
                }
                //if (fileName.Length>480000 || fileName.Length<12000)
                //{
                //    return Json($" اندازه فایل{picture.FileName} صحیح نمیباشد ");
                //}
                if (!fileName.ToLower().EndsWith(".jpg")/* || !fileName.ToLower().EndsWith(".png")*/)
                {
                    return Json($" فرمت فایل{model.Picture.FileName} صحیح نمیباشد ");
                }

                fileName = fileName.ToUniqueFileName();
                var path = $"{env.WebRootPath}/Image/{fileName}";
                FileStream fs = new FileStream(path, FileMode.Create);
                model.Picture.CopyTo(fs);
                model.ImageUrl = $"~/Image/{fileName}";
                model.ImageCode = Guid.NewGuid().ToString();
                var result = _imageBusiness.Add(model);
                if (result.Success==true)
                {
                    x++;
                }
                else
                {
                    return Json($" افزودن فایل{model.Picture.FileName} با خطا مواجه بود ");
                }

                
            






            return Json(" افزودن همه موارد موفقیت آمیز بود ");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _imageBusiness.Get(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Update(ImageAddOrEditModel model)
        {
            var result = _imageBusiness.Update(model);
            return Json(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _imageBusiness.Delete(id);
            return Json(result);
        }


        [HttpGet]
        public IActionResult ViewComponents()
        {
            return ViewComponent("Image");
        }

        public void DropDownMenu()
        {
            List<User> List = _userBusiness.GetAll();
            var use = new User
            {
                UserId = 0,
                UserName = " نام کاربری را وارد کنید "

            };
            List.Add(use);
            ViewBag.user = new SelectList(List, "UserId", "UserName");
            List<Product> productList = _productBusiness.GetAll();
            var prod = new Product
            {
                ProductId = 0,
                ProductName = " نام محصول را وارد کنید "
            };
            productList.Add(prod);
            ViewBag.product = new SelectList(productList, "ProductId", "ProductName");
        }
    }
}
