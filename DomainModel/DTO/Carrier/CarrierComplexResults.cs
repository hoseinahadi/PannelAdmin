using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;

namespace DomainModel.DTO.Carrier
{
    public class CarrierComplexResults:IComplexObjectResult<List<CarrierSearchResult>,List<string>>
    {
        private List<CarrierSearchResult> _mainResults;

        public List<CarrierSearchResult> MainResults
        {
            get
            {
                return this._mainResults;
            }
            set
            {
                this._mainResults= value;
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
                this._errors= value;
            }
        }
    }
}
