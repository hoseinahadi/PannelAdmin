using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;
using DomainModel.DTO.Order;
using DomainModel.Models;

namespace DomainModel.DTO.WbBrowser
{
    public class WebBrowserComplexResults:IComplexObjectResult<List<WebBrowser>,List<string>>
    {
        private List<WebBrowser> _mainResults;

        public List<WebBrowser> MainResults
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
