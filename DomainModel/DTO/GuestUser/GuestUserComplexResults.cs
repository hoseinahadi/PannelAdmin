using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;

namespace DomainModel.DTO.GuestUser
{
    public class GuestUserComplexResults:IComplexObjectResult<List<GuestUserSearchResult>,List<string>>
    {
        private List<GuestUserSearchResult> _mainResults;

        public List<GuestUserSearchResult> MainResults
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
