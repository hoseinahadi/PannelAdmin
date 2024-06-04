using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public List<Address> Addresses { get; set; }
        public List<CountryDiscount> CountryDiscounts { get; set; }

        public Country()
        {
            this.Addresses = new List<Address>();
            this.CountryDiscounts= new List<CountryDiscount>();
        }
    }
}
