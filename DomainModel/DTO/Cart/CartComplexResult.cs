using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Carrier;

namespace DomainModel.DTO.Cart
{
    public class CartComplexResult:IComplexObjectResult<List<CartSearchResults>,List<string>>
    {
        private List<CartSearchResults> _mainResults;

        public List<CartSearchResults> MainResults
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
                this.Errors = value;
            }
        }
    }
}
