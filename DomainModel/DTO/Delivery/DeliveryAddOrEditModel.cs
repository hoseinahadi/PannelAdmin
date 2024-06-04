using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Delivery
{
    public class DeliveryAddOrEditModel
    {
        public int DeliveryId { get; set; }
        public int CarrierId { get; set; }
        public int CurrencyId { get; set; }
        [Required(ErrorMessage = " نام حمل را وارد کنید ")]
        [Display(Name = " نام حمل ")]
        public string DeliveryName { get; set; }
        [Display(Name = " هزینه حمل ")]
        public decimal Price { get; set; }

    }
}
