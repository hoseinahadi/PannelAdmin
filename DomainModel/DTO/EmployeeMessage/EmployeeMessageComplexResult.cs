using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.EmployeeMessage
{
    public class EmployeeMessageComplexResult : IComplexObjectResult<List<Models.EmployeeMessage>,List<string>>
    {
        private List<Models.EmployeeMessage> _mainResults;

        public List<Models.EmployeeMessage> MainResults
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
