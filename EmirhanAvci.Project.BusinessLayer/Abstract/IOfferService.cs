using EmirhanAvci.Project.EntityLayer.Dtos.OfferDtos;
using EmirhanAvci.Project.SharedLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.Abstract
{
    public interface IOfferService
    {
        Task<IDataResult<OfferListDto>> GetAllAsync();
        Task<IDataResult<OfferListDto>> GetAllAsync(int productId);
        Task<IDataResult<OfferDto>> GetAsync(int id);
        Task<IResult> AcceptAsync(int id);
        Task<IResult> RejectAsync(int id);
        Task<IResult> AddAsync(OfferAddDto offerAddDto);
        Task<IResult> UpdateAsync(OfferUpdateDto offerUpdateDto);
        Task<IResult> DeleteAsync(int offerId);
        Task<IResult> HardDeleteAsync(int offerId);
    }
}
