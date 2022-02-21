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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result=await _categoryService.GetAllAsync();
            if (result.ResultStatus==ResultStatus.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            var result = await _categoryService.GetAsync(categoryId);
            if (result.ResultStatus==ResultStatus.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody]CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var result=await _categoryService.AddAsync(categoryAddDto, "aaa");
                if (result.ResultStatus==ResultStatus.Success)
                {
                    return Ok(result);

                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.UpdateAsync(categoryUpdateDto);
                if (result.ResultStatus==ResultStatus.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            return BadRequest();
        }

    }
}
