using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Authentication;
using EmirhanAvci.Project.EntityLayer.Dtos.ProductDtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Extensions;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;
        public ProductController(IProductService productService, IWebHostEnvironment env)
        {
            _productService = productService;
            _env = env;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryIdAsync(int categoryId)
        {
            var result = await _productService.GetByCategoryIdAsync(categoryId);
            return Ok(result);
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByProductIdAsync(int productId)
        {
            var result = await _productService.GetAsync(productId);
            return Ok(result);
        }
        [HttpGet("Update/{productId}")]
        public async Task<IActionResult> GetByProductIdForUpdateAsync(int productId)
        {
            var result = await _productService.GetUpdateAsync(productId);
            return Ok(result);
        }

        [HttpGet("Brand/{brandId}")]
        public async Task<IActionResult> GetByBrandIdAsync(int brandId)
        {
            var result = await _productService.GetByBrandIdAsync(brandId);
            return Ok(result);
        }

        [HttpGet("Color/{colorId}")]
        public async Task<IActionResult> GetByColorId(int colorId)
        {
            var result = await _productService.GetByColorIdAsync(colorId);
            return Ok(result);
        }
        [Authorize]
        [HttpPut("UpdateAsync/{productId}")]
        public async Task<IActionResult> UpdateAsync(int productId, ProductUpdateDto productUpdateDto)
        {
            productUpdateDto.Id = productId;
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
        [Authorize]
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
        [Authorize]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> HardDeleteAsync(int productId)
        {
            var result = await _productService.HardDeleteAsync(productId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(); }
        }

        [HttpPost("AddAsync")]
        //[Authorize(Roles = Role.User)]

        public async Task<IActionResult> AddAsync([FromBody] ProductAddDto productAddDto)
        {
            if (productAddDto.ImageFile!=null && productAddDto.ImageFile.Length<400000)
            {
                string startupPath = System.IO.Directory.GetCurrentDirectory();
                string otherPath = startupPath.Substring(0, startupPath.Length - 6) + "UI\\wwwroot";
                string wwwroot = otherPath;  //wwwroot folderpath
                string fileName2 = Path.GetFileNameWithoutExtension(productAddDto.ImageFile.FileName);

                string fileExtension = Path.GetExtension(productAddDto.ImageFile.FileName);
                DateTime dateTime = DateTime.Now;
                string fileName = $"{productAddDto.Name}_{dateTime.FullDateAndTimeStringWithUnderScore()}_{fileName2}{fileExtension}";
                var path = Path.Combine($"{ wwwroot}/img", fileName);

                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await productAddDto.ImageFile.CopyToAsync(stream);
                }
                if (ModelState.IsValid)
                {
                    productAddDto.ImagePath = fileName;
                }
            }
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
            if (result.ResultStatus == ResultStatus.Success)
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
