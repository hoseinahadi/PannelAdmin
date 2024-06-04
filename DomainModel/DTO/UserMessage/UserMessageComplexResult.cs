using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.UserMessage
{
    public class UserMessageComplexResult : IComplexObjectResult<List<Models.UserMessage>,List<string>>
    {
        private List<Models.UserMessage> _mainResults;

        public List<Models.UserMessage> MainResults
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
