using System.Collections.Generic;

namespace DomainModel.Models
{
  public  class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<RoleAction> RoleActions { get; set; }
        public List<User> Users { get; set; }
        public List<Employee> Employees { get; set; }

        public Role()
        {
            this.Users = new List<User>();
            this.Employees = new List<Employee>();
            this.RoleActions = new List<RoleAction>();
        }
    }
}
