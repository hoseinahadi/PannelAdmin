using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Employee;

namespace DomainModel.DTO.Feature
{
    public class FeatureComplexResults:IComplexObjectResult<List<FeatureSearchResult>,List<string>>
    {
        private List<FeatureSearchResult> _mainResults;

        public List<FeatureSearchResult> MainResults
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
