using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public List<User> Users { get; set; }

        public Gender()
        {
            this.Users = new List<User>();
        }

    }
}
