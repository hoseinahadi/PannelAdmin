using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Tax
{
    public class TaxSearchResult
    {
        public int TaxId { get; set; }
        public int TaxPercent { get; set; }
        public string TaxName { get; set; }
    }
}
