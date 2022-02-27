using AutoMapper;
using EmirhanAvci.Project.BusinessLayer.Abstract;
using EmirhanAvci.Project.DataAccessLayer.Abstract;
using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos.OfferDtos;
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
    public class OfferManager : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfferManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> AcceptAsync(int id)
        {
            var offer = await _unitOfWork.Offers.GetAsync(o => o.Id == id);
            offer.IsAccepted = true;
            await _unitOfWork.Offers.UpdateAsync(offer).ContinueWith(c => _unitOfWork.SaveAsync());
            return new Result(resultStatus: ResultStatus.Success, message: $"offer updated");
        }

        public async Task<IResult> AddAsync(OfferAddDto offerAddDto)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.Id == offerAddDto.ProductId);
            if (product.IsOfferable == true)
            {
                var offer = _mapper.Map<Offer>(offerAddDto);
                offer.CreatedByName = "Created";
                offer.ModifiedByName = "Created";
                offer.CreatedDate = DateTime.Now;
                offer.ModifiedDate = DateTime.Now;
                await _unitOfWork.Offers.AddAsync(offer).ContinueWith(continuationAction: c => _unitOfWork.SaveAsync());
                return new Result(resultStatus: ResultStatus.Success, message: $"{product.Name} offered.");


            }
            else
            {
                return new Result(resultStatus: ResultStatus.Error, message: $"{product.Name} is not offerable");
            }
        }

        public async Task<IResult> DeleteAsync(int offerId)
        {
            var offer = await _unitOfWork.Offers.GetAsync(predicate: c => c.Id == offerId, includeProperties: null);
            if (offer != null)
            {
                offer.IsDeleted = true;
                offer.ModifiedDate = DateTime.Now;
                offer.ModifiedByName = "Deleted";
                offer.ModifiedDate = DateTime.Now;
                await _unitOfWork.Offers.DeleteAsync(offer).ContinueWith(db => _unitOfWork.SaveAsync());
                return new Result(resultStatus: ResultStatus.Success, message: $"offer is deleted completely");
            }
            return new Result(resultStatus: ResultStatus.Error, message: $"offer is not deleted completely");
        }

        public async Task<IDataResult<OfferListDto>> GetAllAsync()
        {
            var offers = await _unitOfWork.Offers.GetAllAsync();
            if (offers.Count > -1)
            {
                return new DataResult<OfferListDto>(resultStatus: ResultStatus.Success, data: new OfferListDto
                {
                    Offers = offers,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<OfferListDto>(resultStatus: ResultStatus.Error, data: null);
            }
        }

        public async Task<IDataResult<OfferListDto>> GetAllAsync(int productId)
        {
            var offers = await _unitOfWork.Offers.GetAllAsync(o => o.ProductId == productId);
            if (offers.Count > -1)
            {
                return new DataResult<OfferListDto>(resultStatus: ResultStatus.Success, data: new OfferListDto
                {
                    Offers = offers,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<OfferListDto>(resultStatus: ResultStatus.Error, data: null);
            }
        }

        public async Task<IDataResult<OfferDto>> GetAsync(int id)
        {
            var offer = await _unitOfWork.Offers.GetAsync(predicate: c => c.Id == id);
            if (offer != null)
            {
                return new DataResult<OfferDto>(resultStatus: ResultStatus.Success, data: new OfferDto
                {
                    Offer = offer,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
            {
                return new DataResult<OfferDto>(resultStatus: ResultStatus.Error, message: "Offer is not found", data: null);
            }
        }

        public async Task<IResult> HardDeleteAsync(int offerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RejectAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(OfferUpdateDto offerUpdateDto)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.Id == offerUpdateDto.ProductId);
            if (product.IsOfferable == true)
            {
                var offer = _mapper.Map<Offer>(offerUpdateDto);
                offer.ModifiedByName = "updated";
                await _unitOfWork.Offers.UpdateAsync(offer).ContinueWith(c => _unitOfWork.SaveAsync());
                return new Result(resultStatus: ResultStatus.Success, message: $"offer updated");
            }
            else
            {
                return new Result(resultStatus: ResultStatus.Success, message: $"offer cant update");
            }

        }
    }
}
