using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.ProductCart
{
    public class ProductCartComplexResult : IComplexObjectResult<List<Models.ProductCart>,List<string>>
    {
        private List<Models.ProductCart> _mainResults;

        public List<Models.ProductCart> MainResults
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
