using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Dtos.ColorDtos;
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
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _colorService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("{colorId}")]
        public async Task<IActionResult> GetById(int colorId)
        {
            var result = await _colorService.GetAsync(colorId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] ColorAddDto colorAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _colorService.AddAsync(colorAddDto);
                if (result.ResultStatus == ResultStatus.Success)
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
        [HttpPut("{colorId}")]
        public async Task<IActionResult> UpdateAsync(int colorId, ColorUpdateDto colorUpdateDto)
        {
            colorUpdateDto.Id = colorId;
            if (ModelState.IsValid)
            {
                var result = await _colorService.UpdateAsync(colorUpdateDto);
                if (result.ResultStatus == ResultStatus.Success)
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
