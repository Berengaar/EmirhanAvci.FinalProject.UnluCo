using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos;
using EmirhanAvci.Project.EntityLayer.Dtos.SubDtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> GetAsync(int productId);
        Task<IDataResult<ProductOffersDtos>> GetProductOffersAsync(int productId);
        Task<IDataResult<ProductListDto>> GetAllAsync(); 
        Task<IDataResult<ProductListDto>> GetByColorIdAsync(int colorId);
        Task<IDataResult<ProductListDto>> GetByBrandIdAsync(int brandId);
        Task<IDataResult<ProductListDto>> GetByCategoryIdAsync(int categoryId);
        Task<IDataResult<ProductListDto>> GetByUserIdAsync(int userId);
        Task<IResult> AddAsync(ProductAddDto productAddDto);
        Task<IResult> UpdateAsync( ProductUpdateDto productUpdateDto);
        Task<IResult> DeleteAsync(int productId);
        Task<IResult> HardDeleteAsync(int productId);
    }
}
