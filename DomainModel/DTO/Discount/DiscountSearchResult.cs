using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Discount
{
    public class DiscountSearchResult
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public float Percent { get; set; }
        public List<Models.Category> Categories { get; set; }
        public List<Models.User> Users { get; set; }
        public List<Models.Employee> Employees { get; set; }
        public List<Models.Country> Countries { get; set; }
        public List<Models.Order> Orders { get; set; }
        public List<Models.Product> Products { get; set; }
    }
}
