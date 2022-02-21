using AutoMapper;
using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.AutoMapper.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductDto, Product>();
        }
    }
}
