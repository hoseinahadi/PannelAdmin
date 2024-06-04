using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.SupplierImage
{
    public class SupplierImageComplexResult : IComplexObjectResult<List<Models.SupplierImage>,List<string>>
    {
        private List<Models.SupplierImage> _mainResults;

        public List<Models.SupplierImage> MainResults
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
