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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            await _unitOfWork.Categories.AddAsync(category);

            return new Result(resultStatus: ResultStatus.Success, message: $"{category.Name} added successfully.");
        }

        public async Task<IResult> DeleteAsync(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(predicate: c => c.Id == categoryId, includeProperties: c => c.Products);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.DeleteAsync(category);
                return new Result(resultStatus: ResultStatus.Success, message: $"{category.Name} is deleted completely");
            }
            return new Result(resultStatus: ResultStatus.Error, message: $"{category.Name} is not deleted completely");
        }

        public async Task<IDataResult<CategoryDto>> GetAsync(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(predicate: c => c.Id == categoryId, includeProperties: c => c.Products);
            if (category != null)
            {
                return new DataResult<CategoryDto>(resultStatus: ResultStatus.Success, data: new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<CategoryDto>(resultStatus: ResultStatus.Error, message: "Category is not found", data: null);
            }
        }

        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(predicate: null, c => c.Products);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(resultStatus: ResultStatus.Success, data: new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<CategoryListDto>(resultStatus: ResultStatus.Error, message: "Categories not found", data: null);
            }
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(predicate: c => c.IsDeleted == false, includeProperties: c => c.Products);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(resultStatus: ResultStatus.Success, data: new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<CategoryListDto>(resultStatus: ResultStatus.Error, message: "Cateories not found", data: null);
            }
        }

        public async Task<IResult> HardDeleteAsync(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(predicate: c => c.Id == categoryId, includeProperties: c => c.Products);
            if (category != null)
            {
                category.IsDeleted = true;
                category.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(category);
                return new Result(resultStatus: ResultStatus.Success, message: $"{category.Name} is deleted");
            }
            return new Result(resultStatus: ResultStatus.Error, message: $"{category.Name} is not deleted");
        }

        public async Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category =  _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = "AA";
            category.CreatedByName = "AA";
            await _unitOfWork.Categories.UpdateAsync(category);
            return new Result(resultStatus: ResultStatus.Success, message: $"{categoryUpdateDto} updated");

        }
    }
}
