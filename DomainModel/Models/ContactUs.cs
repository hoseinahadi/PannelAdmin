using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ContactUs
    {
        public int ContactUsId { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
