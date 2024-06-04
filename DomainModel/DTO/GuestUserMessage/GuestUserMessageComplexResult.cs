using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.GuestUserMessage
{
    public class GuestUserMessageComplexResult : IComplexObjectResult<List<Models.GuestUserMessage>,List<string>>
    {
        private List<Models.GuestUserMessage> _mainResults;

        public List<Models.GuestUserMessage> MainResults
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
