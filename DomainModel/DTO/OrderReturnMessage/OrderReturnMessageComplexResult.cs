using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.OrderReturnMessage
{
    public class OrderReturnMessageComplexResult : IComplexObjectResult<List<Models.OrderReturnMessage>,List<string>>
    {
        private List<Models.OrderReturnMessage> _mainResults;

        public List<Models.OrderReturnMessage> MainResults
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
