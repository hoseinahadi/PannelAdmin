using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Cart;

namespace DomainModel.DTO.Category
{
    public class CategoryComplexResult:IComplexObjectResult<List<CategorySearchResult>,List<string>>
    {
        private List<CategorySearchResult> _mainResults;

        public List<CategorySearchResult> MainResults
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
