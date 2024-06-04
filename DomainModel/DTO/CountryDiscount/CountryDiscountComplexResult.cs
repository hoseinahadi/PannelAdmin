using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.CountryDiscount
{
    public class CountryDiscountComplexResult : IComplexObjectResult<List<Models.CountryDiscount>,List<string>>
    {
        private List<Models.CountryDiscount> _mainResults;

        public List<Models.CountryDiscount> MainResults
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
                return this.Errors;
            }
            set
            {
                this._errors = value;
            }
        }
    }
}
