using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.CategoryDiscount
{
    public class CategoryDiscountComplexResult : IComplexObjectResult<List<Models.CategoryDiscount>,List<string>>
    {
        private List<Models.CategoryDiscount> _mainResults;

        public List<Models.CategoryDiscount> MainResults
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
