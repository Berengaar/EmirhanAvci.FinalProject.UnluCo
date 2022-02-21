using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.SharedLayer.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus,string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public Result(ResultStatus resultStatus, string message,Exception ex)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = ex;
        }
        public ResultStatus ResultStatus { get ; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
