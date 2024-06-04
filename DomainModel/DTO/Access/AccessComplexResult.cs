using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;

namespace DomainModel.DTO.Access
{
    public class AccessComplexResult : IComplexObjectResult<List<AccessSearchResult>,List<string>>
    {
        private List<AccessSearchResult> _mainResults;

        public List<AccessSearchResult> MainResults
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
