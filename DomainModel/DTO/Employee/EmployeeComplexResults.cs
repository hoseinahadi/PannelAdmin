using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Discount;

namespace DomainModel.DTO.Employee
{
    public class EmployeeComplexResults:IComplexObjectResult<List<EmployeeSearchResult>,List<string>>
    {
        private List<EmployeeSearchResult> _mainResults;

        public List<EmployeeSearchResult> MainResults
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
