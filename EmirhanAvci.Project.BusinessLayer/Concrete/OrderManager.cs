using AutoMapper;
using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos.OrderDtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.ComplexTypes;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(OrderAddDto orderAddDto)
        {
            var control = await ControlOrderAsync(orderAddDto.ProductId);
            if (control.ResultStatus == ResultStatus.Success)
            {
                var order = _mapper.Map<Order>(orderAddDto);
                order.CreatedByName = "Created order";
                order.ModifiedByName = "Created order";
                order.CreatedDate = DateTime.Now;
                order.ModifiedDate = DateTime.Now;
                await _unitOfWork.Orders.AddAsync(order).ContinueWith(continuationAction: c => _unitOfWork.SaveAsync());
                return new Result(resultStatus: ResultStatus.Success, message: $"Order entry completed.");
            }
            else
            {
                return new Result(resultStatus: ResultStatus.Error, message: $"Order entry didn't complete.");

            }
        }

        public async Task<IResult> ControlOrderAsync(int productId)
        {
            var offers = _unitOfWork.Offers.GetAllAsync(of => of.ProductId == productId);
            var acceptedOffer = offers.Result.SingleOrDefault(s => s.IsAccepted == true);
            if (acceptedOffer != null)
            {
                return new Result(resultStatus: ResultStatus.Success, message: $"Order entry is possible");
            }
            else
            {
                return new Result(resultStatus: ResultStatus.Error, message: "$Order entry is not possible");
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetAsync(predicate: c => c.Id == id, includeProperties: null);
            if (order != null)
            {
                order.IsDeleted = true;
                order.ModifiedDate = DateTime.Now;
                order.ModifiedByName = "Deleted";
                order.ModifiedDate = DateTime.Now;
                await _unitOfWork.Orders.DeleteAsync(order).ContinueWith(db => _unitOfWork.SaveAsync());
                return new Result(resultStatus: ResultStatus.Success, message: $"Order is deleted completely");
            }
            return new Result(resultStatus: ResultStatus.Error, message: $"Order is not deleted completely");
        }

        public async Task<IDataResult<OrderListDto>> GetAllUserOrdersAsync(int userId)
        {
            var orders = await _unitOfWork.Orders.GetAllAsync(or => or.UserId == userId);
            if (orders.Count > -1)
            {
                return new DataResult<OrderListDto>(resultStatus: ResultStatus.Success, data: new OrderListDto
                {
                    Orders = orders,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<OrderListDto>(resultStatus: ResultStatus.Error, data: null, message: "Order is not found");
            }
        }

        public async Task<IDataResult<OrderDto>> GetOrderWithProductIdAsync(int productId)
        {
            var order = await _unitOfWork.Orders.GetAsync(or => or.ProductId == productId);
            if (order != null)
            {
                return new DataResult<OrderDto>(resultStatus: ResultStatus.Success, data: new OrderDto
                {
                    Order = order,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<OrderDto>(resultStatus: ResultStatus.Error, data: null, message: "Order is not found");
            }
        }

        public async Task<IResult> HardDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
