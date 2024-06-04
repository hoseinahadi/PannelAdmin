using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Order;

namespace DomainModel.DTO.Supplier
{
    public class SupplierComplexResults:IComplexObjectResult<List<SupplierSearchResult>,List<string>>
    {
        private List<SupplierSearchResult> _mainResults;

        public List<SupplierSearchResult> MainResults
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
