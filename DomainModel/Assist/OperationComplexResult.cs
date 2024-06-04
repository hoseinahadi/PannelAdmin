using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Assist
{
    public class OperationComplexResult<Tmodel>
    {
        public OperationResult OperationResults { get; set; }
        public Tmodel model { get; set; }

        public OperationComplexResult(OperationResult operationResults, Tmodel model)
        {
            OperationResults = operationResults;
            this.model = model;
        }
        public OperationComplexResult(OperationResult operationResults)
        {
            OperationResults = operationResults;
        }
        public OperationComplexResult( Tmodel model)
        {
            this.model = model;
        }
    }
}
