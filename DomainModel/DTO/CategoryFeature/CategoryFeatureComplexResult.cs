using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.CategoryFeature
{
    public class CategoryFeatureComplexResult:IComplexObjectResult<List<Models.CategoryFeature>,List<string>>
    {
        private List<Models.CategoryFeature> _mainResults;

        public List<Models.CategoryFeature> MainResults
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
