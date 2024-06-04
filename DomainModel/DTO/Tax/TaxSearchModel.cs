using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Tax
{
    public class TaxSearchModel : PageModel
    {
        public int TaxPercent { get; set; }
        public string TaxName { get; set; }
    }
}
