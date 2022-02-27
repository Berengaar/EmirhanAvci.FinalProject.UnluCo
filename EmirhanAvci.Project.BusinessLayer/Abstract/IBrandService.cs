using EmirhanAvci.Project.EntityLayer.Dtos.BrandDtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.Abstract
{
    public interface IBrandService
    {
        Task<IDataResult<BrandDto>> GetAsync(int brandId);
        Task<IDataResult<BrandListDto>> GetAllAsync();
        Task<IDataResult<BrandListDto>> GetAllByNonDeletedAsync();
        Task<IResult> AddAsync(BrandAddDto brandAddDto, string createdByName);
        Task<IResult> UpdateAsync(BrandUpdateDto brandUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int brandId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int brandId);
    }
}
