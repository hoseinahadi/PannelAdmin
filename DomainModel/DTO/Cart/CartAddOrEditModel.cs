using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Cart
{
    public class CartAddOrEditModel
    {
        public int CartId { get; set; }
        public DateTime AddDate { get; set; }
        public int UserId { get; set; }
        
    }
}
