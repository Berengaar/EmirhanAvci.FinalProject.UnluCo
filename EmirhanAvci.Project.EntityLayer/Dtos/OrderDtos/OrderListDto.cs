using EmirhanAvci.Project.SharedLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Dtos.OrderDtos
{
    public class OrderListDto:DtoGetBase
    {
        public IList<OrderDto> Orders { get; set; }
    }
}
