using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Discount
{
    public class DiscountSearchModel : PageModel
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public float Percent { get; set; }
    }
}
