using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.SharedLayer.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, Exception ex, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = ex;
            Data = data;
        }
        public T Data { get; }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}

/*

 */