using System.Collections.Generic;
using DomainModel.Assist;

namespace DomainModel.DTO.UserFavorite
{
    public class UserFavoriteComplexResult : IComplexObjectResult<List<Models.UserFavorite>,List<string>>
    {
        private List<Models.UserFavorite> _mainResults;

        public List<Models.UserFavorite> MainResults
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
