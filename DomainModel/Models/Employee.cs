using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int AccessId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastPassword { get; set; }
        public bool Active { get; set; }
        public Employee Parent { get; set; }
        public int? ParentId { get; set; }
        public Access Access { get; set; }
        public Role Role { get; set; }
        public List<EmployeeMessage> EmployeeMessages { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderReturn> OrderReturns { get; set; }
        public List<EmployeeDiscount> EmployeeDiscounts { get; set; }
        public List<Image> Images { get; set; }
        public List<Conversation> Conversations { get; set; }

        public Employee()
        {
            this.EmployeeMessages= new List<EmployeeMessage>();
            this.Addresses= new List<Address>();
            this.Orders= new List<Order>();
            this.EmployeeDiscounts= new List<EmployeeDiscount>();
            this.Images= new List<Image>();
            this.OrderReturns = new List<OrderReturn>();
            this.Conversations=new List<Conversation>();
        }

    }
}
