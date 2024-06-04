using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Employee
{
    public class EmployeeSearchResult
    {
        public int EmployeeId { get; set; }
        public int AccessId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastPassword { get; set; }

        public bool Active { get; set; }
        public Models.Employee Parent { get; set; }
        public Models.Access Access { get; set; }
        public List<Models.Message> Messages { get; set; }
        public List<Models.Address> Addresses { get; set; }
        public List<Models.Order> Orders { get; set; }
        public List<Models.OrderReturn> OrderReturns { get; set; }
        public List<Models.Discount> Discounts { get; set; }
        public List<Models.Image> Images { get; set; }
    }
}
