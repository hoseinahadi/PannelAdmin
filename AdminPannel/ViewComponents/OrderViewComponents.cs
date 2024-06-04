using BusinessServices.Services;
using DomainModel.DTO.Message;
using DomainModel.DTO.Order;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.ViewComponents
{
    [ViewComponent(Name = "Order")]
    public class OrderViewComponents : ViewComponent
    {
        private readonly IOrderBusiness _orderBusiness;

        public OrderViewComponents(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }
        public IViewComponentResult Invoke()
        {
            var order = _orderBusiness.GetAll();
            var orderSearchResultList = new List<OrderSearchResult>();
            foreach (var item in order)
            {
                var orderSearchResult = new OrderSearchResult
                {
                    UserId = item.UserId,
                    EmployeeId = item.EmployeeId.Value,
                    AddressId = item.AddressId,
                    CurrencyId = item.CurrencyId,
                    
                    OrderId = item.OrderId,
                    Payment = item.Payment,
                    ProductCount = item.ProductCount,
                    SecureKey = item.SecureKey,
                    ShoppingPhone = item.ShoppingPhone
                };
                orderSearchResultList.Add(orderSearchResult);
            }
            return View(orderSearchResultList);
        }
    }
}
