using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.ProductCategory
{
    public class ProductCategoryComplexResult : IComplexObjectResult<List<Models.ProductCategory>,List<string>>
    {
        private List<Models.ProductCategory> _mainResults;

        public List<Models.ProductCategory> MainResults
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
