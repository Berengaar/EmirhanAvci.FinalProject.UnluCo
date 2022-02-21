using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Dtos;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = _productService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetByCategoryIdAsync(int categoryId)
        {
            var result = await _productService.GetByCategoryIdAsync(categoryId);
            return Ok(result);
        }

        [HttpGet("{brandId}")]
        public async Task<IActionResult> GetByBrandIdAsync(int brandId)
        {
            var result = await _productService.GetByBrandIdAsync(brandId);
            return Ok(result);
        }

        [HttpGet("{colorId}")]
        public async Task<IActionResult> GetByColorId(int colorId)
        {
            var result = await _productService.GetByColorIdAsync(colorId);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductUpdateDto productUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.UpdateAsync(productUpdateDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }

        [HttpPut("Delete/{productId}")]
        public async Task<IActionResult> DeleteAsync(int productId)
        {
            if (productId > 0)
            {
                var result = await _productService.DeleteAsync(productId);
                return Ok(result);
            }
            else { return BadRequest(); }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> HardDeleteAsync(int productId)
        {
            var result = await _productService.HardDeleteAsync(productId);
            if (result.ResultStatus==ResultStatus.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(); }
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] ProductAddDto productAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.AddAsync(productAddDto);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("Offers/{productId}")]
        public async Task<IActionResult> GetProductOffersAsync(int productId) 
        {
            var result = await _productService.GetProductOffersAsync(productId);
            if (result.ResultStatus==ResultStatus.Success)
            {
                return Ok(result);
            }
            else { return BadRequest("Bişeyler yanlış"); }
        }
        [HttpGet("Order/{productId}")]
        public async Task<IActionResult> GetProductOrder(int productId)
        {
            var result = await _productService.GetProductOffersAsync(productId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            else { return BadRequest("Bişeyler yanlış"); }
        }
    }
}
