using AutoMapper;
using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos.ProductDtos;
using EmirhanAvci.Project.EntityLayer.Dtos.OfferDtos;
using EmirhanAvci.Project.EntityLayer.Dtos.SubDtos;
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
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IProductService _productService;
        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_productService = productService;
        }

        public async Task<IResult> AddAsync(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            product.IsOfferable = true;
            product.CreatedByName = "Added";
            product.CreatedDate = DateTime.Now;
            product.ModifiedByName = "Added";
            product.ModifiedDate = DateTime.Now;
            await _unitOfWork.Products.AddAsync(product).ContinueWith(continuationAction: c => _unitOfWork.SaveAsync()); ;
            return new Result(resultStatus: ResultStatus.Success, message: $"{product.Name} added successfully.");
        }

        public async Task<IResult> DeleteAsync(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(predicate: c => c.Id == productId, includeProperties: null);
            if (product != null)
            {
                product.IsDeleted = true;
                product.IsOfferable = false;
                product.ModifiedDate = DateTime.Now;
                product.ModifiedByName = "Deleted";
                product.ModifiedDate = DateTime.Now;
                await _unitOfWork.Products.DeleteAsync(product).ContinueWith(db => _unitOfWork.SaveAsync());
                return new Result(resultStatus: ResultStatus.Success, message: $"{product.Name} is deleted completely");
            }
            return new Result(resultStatus: ResultStatus.Error, message: $"{product.Name} is not deleted completely");

        }

        public async Task<IDataResult<ProductListDto>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(resultStatus: ResultStatus.Success, data: new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ProductListDto>(resultStatus: ResultStatus.Error, data: null);
            }
        }

        public async Task<IDataResult<ProductDto>> GetAsync(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(predicate: c => c.Id == productId);
            if (product != null)
            {
                return new DataResult<ProductDto>(resultStatus: ResultStatus.Success, data: new ProductDto
                {
                    Product = product,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ProductDto>(resultStatus: ResultStatus.Error, message: "Product is not found", data: null);
            }
        }

        public async Task<IDataResult<ProductListDto>> GetByBrandIdAsync(int brandId)
        {
            var products = await _unitOfWork.Products.GetAllAsync(predicate: p => p.BrandId == brandId);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(resultStatus: ResultStatus.Success, data: new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ProductListDto>(resultStatus: ResultStatus.Error, message: "Products not found", data: null);
            }
        }

        public async Task<IDataResult<ProductListDto>> GetByCategoryIdAsync(int categoryId)
        {
            var products = await _unitOfWork.Products.GetAllAsync(predicate: p => p.CategoryId == categoryId);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(resultStatus: ResultStatus.Success, data: new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ProductListDto>(resultStatus: ResultStatus.Error, message: "Products not found", data: null);
            }
        }

        public async Task<IDataResult<ProductListDto>> GetByColorIdAsync(int colorId)
        {
            var products = await _unitOfWork.Products.GetAllAsync(predicate: p => p.ColorId == colorId);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(resultStatus: ResultStatus.Success, data: new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ProductListDto>(resultStatus: ResultStatus.Error, message: "Products not found", data: null);
            }
        }

        public async Task<IDataResult<ProductListDto>> GetByUserIdAsync(int userId)
        {
            var products = await _unitOfWork.Products.GetAllAsync(predicate: p => p.UserId == userId);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(resultStatus: ResultStatus.Success, data: new ProductListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ProductListDto>(resultStatus: ResultStatus.Error, message: "Products not found", data: null);
            }
        }

        public async Task<IResult> HardDeleteAsync(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(predicate: p => p.Id == productId);
            if (product != null)
            {
                product.IsDeleted = true;
                product.ModifiedDate = DateTime.Now;
                await _unitOfWork.Products.UpdateAsync(product);
                return new Result(resultStatus: ResultStatus.Success, message: $"{product.Name} is deleted");
            }
            return new Result(resultStatus: ResultStatus.Error, message: $"{product.Name} is not deleted");
        }

        public async Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Product>(productUpdateDto);
            product.IsOfferable = true;
            product.ModifiedByName = "updated";
            product.CreatedByName = "updated";
            await _unitOfWork.Products.UpdateAsync(product);
            return new Result(resultStatus: ResultStatus.Success, message: $"{product.Name} updated");
        }

        public async Task<IDataResult<ProductDto>> GetProductOffersAsync(int productId)
        {
            var productOffers = await _unitOfWork.Products.GetAsync(predicate: p => p.Id == productId, t => t.Offers);
            if (productOffers != null)
            {
                return new DataResult<ProductDto>(resultStatus: ResultStatus.Success, data: new ProductDto
                {
                    Product = productOffers,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<ProductDto>(resultStatus: ResultStatus.Error, data: null);
            }
        }

        public async Task<IResult> UploadAsync(ProductUploadDto productUploadDto)
        {
            var product = _mapper.Map<Product>(productUploadDto);
            product.ModifiedByName = "updated";
            await _unitOfWork.Products.UploadAsync(product).ContinueWith(c => _unitOfWork.SaveAsync());
            return new Result(resultStatus: ResultStatus.Success, message: $"{product.Name}  uploaded");
        }

        public async Task<ProductUpdateDto> GetUpdateAsync(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(predicate: c => c.Id == productId);
            if (product != null)
            {
                return new ProductUpdateDto 
                {
                    BrandId = product.BrandId,
                    UserId = product.UserId,
                    Id=product.Id,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                    Name = product.Name,
                    Description = product.Description,
                    ColorId = product.ColorId
                };
            }
            else
            {
                return null;
            }
        }
    }
}
