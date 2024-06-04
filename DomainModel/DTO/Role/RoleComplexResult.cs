using System.Collections.Generic;
using DomainModel.Assist;


namespace DomainModel.DTO.Role
{
    public class RoleComplexResult:IComplexObjectResult<List<RoleSearchResult>,List<string>>
    {
        private List<RoleSearchResult> _mainResults;

        public List<RoleSearchResult> MainResults
        {
            get
            {
                return _mainResults;
            }
            set
            {
                _mainResults=value;
            }
        }

        private List<string> _errors;

        public List<string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                this._errors = value;
            }
        }
    }
}
