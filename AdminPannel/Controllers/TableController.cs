using System.Runtime.InteropServices.JavaScript;
using BusinessServices.Services;
using DomainModel.DTO.Order;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPannel.Controllers
{
    public class TableController : Controller
    {
        private readonly IOrderBusiness _orderBusiness;

        public TableController(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }
        public JsonResult OnGetRevenueData()
        {
            var orserSearchModel = new OrderSearchModel();
            var x = 10;
            int[] ar2 = {1,8};
            List<int> orderCount = new List<int>();

            string[] Month = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            orserSearchModel.StartSearchDate = new DateTime(DateTime.Now.Year, 03, 20);
            for (var i = 0;i<=DateTime.Now.Month;i++)
            {
                orserSearchModel.EndSearchDate = orserSearchModel.StartSearchDate.AddMonths(1);
                if (orserSearchModel.EndSearchDate>=DateTime.Now)
                {
                    orserSearchModel.EndSearchDate = DateTime.Now;
                    i = 5;
                }
                var Order = _orderBusiness.Search(orserSearchModel , out x).MainResults.Count;
                orderCount.Add(Order);
                orserSearchModel.StartSearchDate = orserSearchModel.EndSearchDate;
            }
            
            
            var countExpense = ar2;
            var monthList = Month;
            return new JsonResult(new { xxx = orderCount, receive = countExpense, month = monthList });
        }

    }
}
