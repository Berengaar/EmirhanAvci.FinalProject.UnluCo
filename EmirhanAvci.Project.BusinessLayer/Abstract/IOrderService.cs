using EmirhanAvci.Project.EntityLayer.Dtos.OrderDtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.Abstract
{
    public interface IOrderService
    {
        Task<IDataResult<OrderDto>> GetOrderWithProductIdAsync(int productId);
        Task<IDataResult<OrderListDto>> GetAllUserOrdersAsync(int userId);
        Task<IResult> ControlOrderAsync(int async);
        Task<IResult> AddAsync(OrderAddDto orderAddDto);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> HardDeleteAsync(int id);
    }
}
