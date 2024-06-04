using DomainModel.DTO.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;

namespace DomainModel.DTO.Location
{
    public class LocationComplexResults:IComplexObjectResult<List<Models.Location>,List<string>>
    {
        private List<Models.Location> _mainResults;

        public List<Models.Location> MainResults
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
