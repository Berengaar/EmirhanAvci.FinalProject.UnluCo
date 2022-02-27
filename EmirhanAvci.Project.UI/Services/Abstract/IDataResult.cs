using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.UI.Services.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }
    }
}
