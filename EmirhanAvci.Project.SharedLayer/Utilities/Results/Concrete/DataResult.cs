using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.SharedLayer.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult()
        {

        }
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
        [JsonInclude]
        public T Data { get;  private set; }
        public ResultStatus ResultStatus { get;  set; }
        public string Message { get;  set; }
        public Exception Exception { get;  set; }
    }
}
