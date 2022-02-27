using AutoMapper;
using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos.BrandDtos;
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
    public class BrandManager : IBrandService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BrandManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(BrandAddDto brandAddDto, string createdByName)
        {
            var brand = _mapper.Map<Brand>(brandAddDto);
            brand.CreatedByName = createdByName;
            brand.ModifiedByName = createdByName;
            await _unitOfWork.Brands.AddAsync(brand);

            return new Result(resultStatus: ResultStatus.Success, message: $"{brand.Name} added successfully.");
        }

        public async Task<IResult> DeleteAsync(int brandId, string modifiedByName)
        {
            var brand = await _unitOfWork.Brands.GetAsync(predicate: c => c.Id == brandId, includeProperties: c => c.Products);
            if (brand != null)
            {
                brand.IsDeleted = true;
                brand.ModifiedByName = modifiedByName;
                brand.ModifiedDate = DateTime.Now;
                await _unitOfWork.Brands.DeleteAsync(brand);
                return new Result(resultStatus: ResultStatus.Success, message: $"{brand.Name} is deleted completely");
            }
            return new Result(resultStatus: ResultStatus.Error, message: $"{brand.Name} is not deleted completely");
        }

        public async Task<IDataResult<BrandListDto>> GetAllAsync()
        {
            var brands = await _unitOfWork.Brands.GetAllAsync(predicate: null, c => c.Products);
            if (brands.Count > -1)
            {
                return new DataResult<BrandListDto>(resultStatus: ResultStatus.Success, data: new BrandListDto
                {
                    Brands = brands,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<BrandListDto>(resultStatus: ResultStatus.Error, message: "Brands not found", data: null);
            }
        }

        public async Task<IDataResult<BrandListDto>> GetAllByNonDeletedAsync()
        {
            var brands = await _unitOfWork.Brands.GetAllAsync(predicate: c => c.IsDeleted == false, includeProperties: c => c.Products);
            if (brands.Count > -1)
            {
                return new DataResult<BrandListDto>(resultStatus: ResultStatus.Success, data: new BrandListDto
                {
                    Brands = brands,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<BrandListDto>(resultStatus: ResultStatus.Error, message: "Brands not found", data: null);
            }
        }

        public async Task<IDataResult<BrandDto>> GetAsync(int brandId)
        {
            var brand = await _unitOfWork.Brands.GetAsync(predicate: c => c.Id == brandId);
            if (brand != null)
            {
                return new DataResult<BrandDto>(resultStatus: ResultStatus.Success, data: new BrandDto
                {
                    Brand = brand,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<BrandDto>(resultStatus: ResultStatus.Error, message: "Brand is not found", data: null);
            }
        }

        public async Task<IResult> HardDeleteAsync(int brandId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(BrandUpdateDto brandUpdateDto, string modifiedByName)
        {
            var brand = _mapper.Map<Brand>(brandUpdateDto);
            brand.ModifiedByName = modifiedByName;
            brand.CreatedByName = modifiedByName;
            await _unitOfWork.Brands.UpdateAsync(brand);
            return new Result(resultStatus: ResultStatus.Success, message: $"{brand.Name} updated");
        }
    }
}
