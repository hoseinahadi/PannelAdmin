using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Currency
{
    public class CurrencySearchResult
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int ConversionRate { get; set; }
    }
}
