using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Image;

namespace DomainModel.DTO.OpSystem
{
    public class OpSystemComplexResults:IComplexObjectResult<List<Models.OpSystem>,List<string>>
    {
        private List<Models.OpSystem> _mainResults;

        public List<Models.OpSystem> MainResults
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
