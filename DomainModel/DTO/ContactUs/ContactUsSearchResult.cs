using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.ContactUs
{
    public class ContactUsSearchResult
    {
        public int ContactUsId { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
