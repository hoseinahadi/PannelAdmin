using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.ProductSupplier
{
    public class ProductSupplierComplexResult : IComplexObjectResult<List<Models.ProductSupplier>,List<string>>
    {
        private List<Models.ProductSupplier> _mainResults;

        public List<Models.ProductSupplier> MainResults
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
