using AutoMapper;
using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos;
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
    public class ColorManager : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorManager(IUnitOfWork unitOfWork,  IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> AddAsync(ColorAddDto colorAddDto, string createdByName)
        {
            var color = _mapper.Map<Color>(colorAddDto);
            color.CreatedByName = createdByName;
            color.ModifiedByName = createdByName;
            await _unitOfWork.Colors.AddAsync(color);

            return new Result(resultStatus: ResultStatus.Success, message: $"{color.Name} added successfully.");
        }

        public async Task<IResult> DeleteAsync(int colorId, string modifiedByName)
        {
            var color = await _unitOfWork.Colors.GetAsync(predicate: c => c.Id == colorId, includeProperties: c => c.Products);
            if (color != null)
            {
                color.IsDeleted = true;
                color.ModifiedByName = modifiedByName;
                color.ModifiedDate = DateTime.Now;
                await _unitOfWork.Colors.DeleteAsync(color);
                return new Result(resultStatus: ResultStatus.Success, message: $"{color.Name} is deleted completely");
            }
            return new Result(resultStatus: ResultStatus.Error, message: $"{color.Name} is not deleted completely");
        }

        public async Task<IDataResult<ColorListDto>> GetAllAsync()
        {
            var colors = await _unitOfWork.Colors.GetAllAsync(predicate: null, c => c.Products);
            if (colors.Count > -1)
            {
                return new DataResult<ColorListDto>(resultStatus: ResultStatus.Success, data: new ColorListDto
                {
                    Colors = colors,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ColorListDto>(resultStatus: ResultStatus.Error, message: "Colors not found", data: null);
            }
        }

        public async Task<IDataResult<ColorListDto>> GetAllByNonDeletedAsync()
        {
            var colors = await _unitOfWork.Colors.GetAllAsync(predicate: c => c.IsDeleted == false, includeProperties: c => c.Products);
            if (colors.Count > -1)
            {
                return new DataResult<ColorListDto>(resultStatus: ResultStatus.Success, data: new ColorListDto
                {
                    Colors = colors,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ColorListDto>(resultStatus: ResultStatus.Error, message: "Colors not found", data: null);
            }
        }

        public async Task<IDataResult<ColorDto>> GetAsync(int colorId)
        {
            var color = await _unitOfWork.Colors.GetAsync(predicate: c => c.Id == colorId, includeProperties: c => c.Products);
            if (color != null)
            {
                return new DataResult<ColorDto>(resultStatus: ResultStatus.Success, data: new ColorDto
                {
                    Color = color,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ColorDto>(resultStatus: ResultStatus.Error, message: "Color is not found", data: null);
            }
        }

        public async Task<IResult> HardDeleteAsync(int colorId)
        {
            var color = await _unitOfWork.Colors.GetAsync(predicate: c => c.Id == colorId, includeProperties: c => c.Products);
            if (color != null)
            {
                color.IsDeleted = true;
                color.ModifiedDate = DateTime.Now;
                await _unitOfWork.Colors.UpdateAsync(color);
                return new Result(resultStatus: ResultStatus.Success, message: $"{color.Name} is deleted");
            }
            return new Result(resultStatus: ResultStatus.Error, message: $"{color.Name} is not deleted");
        }

        public async Task<IResult> UpdateAsync(ColorUpdateDto colorUpdateDto, string modifiedByName)
        {
            var color = _mapper.Map<Color>(colorUpdateDto);
            color.ModifiedByName = modifiedByName;
            color.CreatedByName = modifiedByName;
            await _unitOfWork.Colors.UpdateAsync(color);
            return new Result(resultStatus: ResultStatus.Success, message: $"{color.Name} updated");
        }
    }
}
