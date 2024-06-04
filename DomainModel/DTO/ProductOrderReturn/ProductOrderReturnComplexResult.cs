using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.ProductOrderReturn
{
    public class ProductOrderReturnComplexResult : IComplexObjectResult<List<Models.ProductOrderReturn>,List<string>>
    {
        private List<Models.ProductOrderReturn> _mainResults;

        public List<Models.ProductOrderReturn> MainResults
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
