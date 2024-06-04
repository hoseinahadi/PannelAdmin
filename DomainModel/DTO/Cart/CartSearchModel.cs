using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Cart
{
    public class CartSearchModel : PageModel
    {
        public DateTime AddDate { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }

    }
}
