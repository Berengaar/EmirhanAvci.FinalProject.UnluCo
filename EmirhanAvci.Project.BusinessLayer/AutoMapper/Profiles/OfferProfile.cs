using AutoMapper;
using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos.OfferDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.AutoMapper.Profiles
{
    public class OfferProfile:Profile
    {
        public OfferProfile()
        {
            CreateMap<OfferDto, Offer>();
            CreateMap<OfferAddDto, Offer>();
            CreateMap<OfferUpdateDto, Offer>();
        }
    }
}
