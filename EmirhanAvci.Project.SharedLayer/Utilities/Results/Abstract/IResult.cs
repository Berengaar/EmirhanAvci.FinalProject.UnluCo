using EmirhanAvci.Project.SharedLayer.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract
{
    //Todo: Api to UI 
    public interface IResult
    {
        public ResultStatus ResultStatus { get;}
        public string Message { get; }
        public Exception Exception { get;}
    }
}
