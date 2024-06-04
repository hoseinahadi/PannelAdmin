using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.OrderHistory
{
    public class OrderHistoryComplexResult : IComplexObjectResult<List<Models.OrderHistory>,List<string>>
    {
        private List<Models.OrderHistory> _mainResults;

        public List<Models.OrderHistory> MainResults
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
