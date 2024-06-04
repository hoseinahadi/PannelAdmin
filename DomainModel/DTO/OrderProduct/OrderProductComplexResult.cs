using System.Collections.Generic;
using DomainModel.Assist;


namespace DomainModel.DTO.OrderProduct
{
    public class OrderProductComplexResult : IComplexObjectResult<List<Models.OrderProduct>,List<string>>
    {
        private List<Models.OrderProduct> _mainResults;

        public List<Models.OrderProduct> MainResults
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
