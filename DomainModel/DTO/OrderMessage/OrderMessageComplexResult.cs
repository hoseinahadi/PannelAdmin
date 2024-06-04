using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.OrderMessage
{
    public class OrderMessageComplexResult : IComplexObjectResult<List<Models.OrderMessage>,List<string>>
    {
        private List<Models.OrderMessage> _mainResults;

        public List<Models.OrderMessage> MainResults
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
