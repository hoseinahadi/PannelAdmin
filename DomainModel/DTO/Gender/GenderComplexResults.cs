using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Feature;

namespace DomainModel.DTO.Gender
{
    public class GenderComplexResults:IComplexObjectResult<List<Models.Gender>,List<string>>
    {
        private List<Models.Gender> _mainResults;

        public List<Models.Gender> MainResults
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
                this.Errors = value;
            }
        }
    }
}
