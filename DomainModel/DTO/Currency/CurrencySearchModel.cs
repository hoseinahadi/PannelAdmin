using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Currency
{
    public class CurrencySearchModel : PageModel
    {
        public int CountryId { get; set; }
        public string CurrencyName { get; set; }
    }
}
