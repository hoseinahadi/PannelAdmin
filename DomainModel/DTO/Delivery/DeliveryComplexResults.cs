using DomainModel.DTO.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;

namespace DomainModel.DTO.Delivery
{
    public class DeliveryComplexResults:IComplexObjectResult<List<DeliverySearchResult>,List<string>>
    {
        private List<DeliverySearchResult> _mainResults;

        public List<DeliverySearchResult> MainResults
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
