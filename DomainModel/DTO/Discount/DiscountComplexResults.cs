using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Delivery;

namespace DomainModel.DTO.Discount
{
    public class DiscountComplexResults:IComplexObjectResult<List<DiscountSearchResult>,List<string>>
    {
        private List<DiscountSearchResult> _mainResults;

        public List<DiscountSearchResult> MainResults
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
