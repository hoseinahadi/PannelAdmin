using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Product
{
    public class ProductAddEditModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = " فعال برای فروش ")]
        [Display(Name = " فعال ")]
        public bool OnSale { get; set; }
        [Required(ErrorMessage = "  تعداد محصول را وارد کنید")]
        [Display(Name = " تعداد ")]
        public int Quantity { get; set; }
        public int CurrencyId { get; set; }
        [Required(ErrorMessage = " ارزش محصول را وارد کنید")]
        [Display(Name = " ارزش محصول ")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = " نام محصول را وارد کنید")]
        [Display(Name = " نام محصول ")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = " توضیحات را وارد کنید ")]
        [Display(Name = " توضیحات ")]
        public string Description { get; set; }
        [Required(ErrorMessage = " وضعیت محصول را وارد کنید ")]
        [Display(Name = " وضعیت محصول ")]
        public string State { get; set; }
        [Required(ErrorMessage = " قیمت فروش عمده را وارد کنید ")]
        [Display(Name = " قیمت فروش عمده ")]
        public decimal WholeSalePrice { get; set; }
        [Required(ErrorMessage = " قیمت خرید را وارد کنید ")]
        [Display(Name = " قیمت خرید ")]
        public decimal ByPrice { get; set; }
        public DateTime AddDate { get; set; }



        [Required(ErrorMessage = " دسته بندی را وارد کنید ")]
        [Display(Name = " دسته بندی ")]
        public decimal categoryId { get; set; }


    }
}
