using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Address
{
    public class AddressSearchModel : PageModel
    {
        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public int? CountryId { get; set; }
        public int? EmployeeId { get; set; }
        public int? SupplierId { get; set; }
        public bool State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string plaq { get; set; }
        public string PostCode { get; set; }
        public string CompanyName { get; set; }
        public string Note { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
    }
}
