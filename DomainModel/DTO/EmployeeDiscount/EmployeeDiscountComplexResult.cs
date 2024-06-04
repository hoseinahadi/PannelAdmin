using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.EmployeeDiscount
{
    public class EmployeeDiscountComplexResult : IComplexObjectResult<List<Models.EmployeeDiscount>,List<string>>
    {
        private List<Models.EmployeeDiscount> _mainResults;

        public List<Models.EmployeeDiscount> MainResults
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
