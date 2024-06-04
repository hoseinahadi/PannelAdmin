using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.OrderDiscount
{
    public class OrderDiscountComplexResult : IComplexObjectResult<List<Models.OrderDiscount>,List<string>>
    {
        private List<Models.OrderDiscount> _mainResults;

        public List<Models.OrderDiscount> MainResults
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
