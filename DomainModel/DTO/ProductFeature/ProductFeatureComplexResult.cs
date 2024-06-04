using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.ProductFeature
{
    public class ProductFeatureComplexResult : IComplexObjectResult<List<Models.ProductFeature>,List<string>>
    {
        private List<Models.ProductFeature> _mainResults;

        public List<Models.ProductFeature> MainResults
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
