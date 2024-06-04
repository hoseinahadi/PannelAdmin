using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.DTO.Product;

namespace DomainModel.DTO.Order
{
    public class OrderAddEditModel
    {
        public int OrderId { get; set; }
        public Models.Address Address { get; set; }
        public string UserName { get; set; }

        public string CurrencyName { get; set; }

        public DateTime OrderData { get; set; }
        public string EmployeeName { get; set; }

        public string Payment { get; set; }
        [Required(ErrorMessage = " شماره ثابت فروشگاه را وارد کنید ")]
        [Display(Name = " شماره ثابت فروشگاه ")]
        public string ShoppingPhone { get; set; }
        public string SecureKey { get; set; }
        public int ProductCount { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int CurrencyId { get; set; }
        public int EmployeeId { get; set; }
        public int OrderHistoryId { get; set; }
        public List<ProductSearchModel> Products { get; set; }
        public List<int> productId { get; set; }


    }
}
