using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Country;

namespace DomainModel.DTO.Currency
{
    public class CurrencyComplexResults:IComplexObjectResult<List<CurrencySearchResult>,List<string>>
    {
        private List<CurrencySearchResult> _mainResults;

        public List<CurrencySearchResult> MainResults
        {
            get
            {
                return this._mainResults;
            }
            set
            {
                this._mainResults = value;
            }
        }

        private List<string> _errors;

        public List<string> Errors
        {
            get
            {
                return this._errors;
            }
            set
            {
                this._errors = value;
            }
        }
    }
}
