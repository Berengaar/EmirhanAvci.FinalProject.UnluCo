using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Dtos.OrderDtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrdersWithUserIdAsync(int userId)
        {
            var result = await _orderService.GetAllUserOrdersAsync(userId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetOrdersWithProductIdAsync(int productId)
        {
            var result = await _orderService.GetOrderWithProductIdAsync(productId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(OrderAddDto orderAddDto)
        {
            var result = await _orderService.AddAsync(orderAddDto);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
