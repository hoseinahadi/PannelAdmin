using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.ProductDiscount
{
    public class ProductDiscountComplexResult : IComplexObjectResult<List<Models.ProductDiscount>,List<string>>
    {
        private List<Models.ProductDiscount> _mainResults;

        public List<Models.ProductDiscount> MainResults
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
