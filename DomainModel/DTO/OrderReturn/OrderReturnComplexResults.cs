using DomainModel.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;

namespace DomainModel.DTO.OrderReturn
{
    public class OrderReturnComplexResults:IComplexObjectResult<List<OrderReturnSearchResult>,List<string>>
    {
        private List<OrderReturnSearchResult> _mainResults;

        public List<OrderReturnSearchResult> MainResults
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
