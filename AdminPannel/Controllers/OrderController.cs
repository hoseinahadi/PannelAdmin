using BusinessServices.Services;
using DomainModel.Assist;
using DomainModel.DTO.Address;
using DomainModel.DTO.Currency;
using DomainModel.DTO.Order;
using DomainModel.DTO.User;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdminPannel.Controllers
{
    public class OrderController : Controller
    {
        
        private readonly IOrderBusiness _orderBusiness;
        private readonly IAddressBusiness _addressBusiness;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrencyBusiness _currencyBusiness;
        private readonly IUserBusiness _userBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly IOrderProductBusiness _orderProductBusiness;

        public OrderController(IOrderBusiness orderBusiness, IAddressBusiness addressBusiness, IHttpContextAccessor httpContextAccessor, ICurrencyBusiness currencyBusiness, IUserBusiness userBusiness, IProductBusiness productBusiness, IOrderProductBusiness orderProductBusiness)
        {
            _orderBusiness = orderBusiness;
            _addressBusiness = addressBusiness;
            _httpContextAccessor = httpContextAccessor;
            _currencyBusiness = currencyBusiness;
            _userBusiness = userBusiness;
            _productBusiness = productBusiness;
            _orderProductBusiness = orderProductBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteOrder(int orderId)
        {
            var result = _orderBusiness.Delete(orderId);
            return Json(result);
        }
        [HttpGet]
        public IActionResult UpdateOrderPage(int orderId)
        {
            var order = _orderBusiness.Get(orderId);
            return View(order);
        }
        [HttpGet]
        public IActionResult AddNewOrderPage(int orderId)
        {
            List<Product> userList = _productBusiness.GetAll();
            ViewBag.ShowMembers = new SelectList(userList, "ProductId", "ProductName");
            return View();
        }
        [HttpPost]
        public IActionResult AddNewOrder(OrderAddEditModel order)
        {
            
            var random = new Random();
            if (order.Payment==null)
            {
                order.Payment = "";
            }

            order.ProductCount = order.productId.Count;
            order.SecureKey = random.Next(1000000000).ToString();
            var x = 10;
            if (order.UserId==null)
            {
                return Json(" نام کاربری را وارد کنید ");
            }
            else
            {
                var user = _userBusiness.GetUserByUserName(order.UserName);
                if (user==null)
                {
                    return Json(" این کاربر یافت نشد ");
                }
                order.UserId = user.UserId;
                var employeeId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
                order.EmployeeId = Convert.ToInt32(employeeId);
                if (order.CurrencyName==null)
                {
                    return Json(" واحد پولی را وارد کنید ");
                }
                var currencySearchModel = new CurrencySearchModel
                {
                    CurrencyName = order.CurrencyName
                };
                var currencyIsExist = _currencyBusiness.Search(currencySearchModel, out x);
                
                if (currencyIsExist.MainResults.Count != 0)
                {
                    foreach (var item in currencyIsExist.MainResults)
                    {
                        order.CurrencyId = item.CurrencyId;
                    }

                    var result = new OperationResult(" افزودن سفارش ");
                    if (order.Address != null)
                    {
                        var addressSearchModel = new AddressSearchModel
                        {
                            City = order.Address.City,
                            State = order.Address.State,
                            MobileNumber = order.Address.MobileNumber,
                            PostCode = order.Address.PostCode,
                            Street = order.Address.Street,
                            plaq = order.Address.plaq,
                        };
                        var addressIsExist = _addressBusiness.Search(addressSearchModel, out x);

                        if (addressIsExist.MainResults.Count != 0)
                        {

                            foreach (var item in addressIsExist.MainResults)
                            {
                                order.AddressId = item.AddressId;
                                order.Address.AddressId = item.AddressId;

                            }

                            int paymen = 0;
                            foreach (var item in order.productId)
                            {
                                var prod = _productBusiness.Get(item);
                                paymen += (int) prod.Price;
                            }

                            order.Payment = paymen.ToString();
                            result = _orderBusiness.Add(order);
                            
                            if (order.productId.Count != 0)
                            {
                                foreach (var item in order.productId)
                                {
                                    
                                    var orderProd = new OrderProduct
                                    {
                                        OrderId = result.RecordId,
                                        ProductId = item
                                    };
                                    var orderProductresult = _orderProductBusiness.Add(orderProd);
                                    if (orderProductresult.Success==false)
                                    {
                                        return Json(" اضافه کردن جدول واسط با مشکلاتی همراه بود "+orderProductresult.Message);
                                    }
                                }

                                
                            }
                            return Json(result);
                        }
                        var addressAddEditModel = new AddressAddOrEditModel
                        {
                            City = order.Address.City,
                            State = order.Address.State,
                            MobileNumber = order.Address.MobileNumber,
                            PostCode = order.Address.PostCode,
                            Street = order.Address.Street,
                            plaq = order.Address.plaq,
                        };
                        var address = _addressBusiness.Add(addressAddEditModel);
                        if (address.Success == true)
                        {
                            order.AddressId = address.RecordId;
                            result = _orderBusiness.Add(order);
                            return Json(result);
                        }
                        if (address.Success == false)
                        {
                            return Json(" افزودن آدرس با خطا  همراه بود ");
                        }
                    }
                    return Json(" آدرس را وارد کنید ");
                }
                return Json(" واحد پولی یافت نشد ");
            }
            
        }
        [HttpPost]
        public IActionResult UpdateOrder(OrderAddEditModel order)
        {
            if (order.Payment==null)
            {
                order.Payment = "";
            }
            
            
            var result = _orderBusiness.Update(order);
            return Json(result);
        }
        [HttpGet]
        public IActionResult OrderDetails(int orderId)
        {
            var order = _orderBusiness.Get(orderId);

            return View(order);
        }
    }
}
