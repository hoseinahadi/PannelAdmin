using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Assist
{
    public interface IComplexObjectResult<TModel,TErrorResult>
    {
        TModel MainResults { get; set; }
        TErrorResult Errors { get; set; }
    }
}
