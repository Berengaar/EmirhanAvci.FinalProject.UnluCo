using EmirhanAvci.Project.EntityLayer.Dtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.Abstract
{
    public interface IColorService
    {
        Task<IDataResult<ColorDto>> GetAsync(int colorId);
        Task<IDataResult<ColorListDto>> GetAllAsync();
        Task<IDataResult<ColorListDto>> GetAllByNonDeletedAsync();
        Task<IResult> AddAsync(ColorAddDto colorAddDto, string createdByName);
        Task<IResult> UpdateAsync(ColorUpdateDto colorUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int colorId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int colorId);
    }
}
