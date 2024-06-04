using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Access
    {
        public int AccessId { get; set; }
        public string AccessLevel { get; set; }
        public List<Employee> Employees { get; set; }

        public Access()
        {
            this.Employees= new List<Employee>();
        }
    }
}
