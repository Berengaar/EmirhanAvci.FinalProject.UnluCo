using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Authentication;
using EmirhanAvci.Project.EntityLayer.Dtos.BrandDtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        //[Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _brandService.GetAllAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("{brandId}")]
        public async Task<IActionResult> GetById(int brandId)
        {
            var result = await _brandService.GetAsync(brandId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        [Authorize]
        public async Task<IActionResult> AddAsync([FromBody]BrandAddDto brandAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _brandService.AddAsync(brandAddDto, "aaa");
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
        [HttpPut("{brandId}")]
        public async Task<IActionResult> UpdateAsync(int brandId, BrandUpdateDto brandUpdateDto)
        {
            brandUpdateDto.Id = brandId;
            if (ModelState.IsValid)
            {
                var result = await _brandService.UpdateAsync(brandUpdateDto, "aaa");
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
