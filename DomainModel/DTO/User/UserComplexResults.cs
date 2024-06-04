using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Tax;

namespace DomainModel.DTO.User
{
    public class UserComplexResults:IComplexObjectResult<List<UserSearchResult>,List<string>>
    {
        private List<UserSearchResult> _mainResults;

        public List<UserSearchResult> MainResults
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
