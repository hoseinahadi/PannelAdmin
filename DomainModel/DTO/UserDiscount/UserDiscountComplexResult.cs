using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.UserDiscount
{
    public class UserDiscountComplexResult : IComplexObjectResult<List<Models.UserDiscount>,List<string>>
    {
        private List<Models.UserDiscount> _mainResults;

        public List<Models.UserDiscount> MainResults
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
