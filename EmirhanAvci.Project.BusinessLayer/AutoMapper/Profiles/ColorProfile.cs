using AutoMapper;
using EmirhanAvci.Project.EntityLayer.Concrete;
using EmirhanAvci.Project.EntityLayer.Dtos.ColorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.BusinessLayer.AutoMapper.Profiles
{
    public class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<ColorAddDto, Color>();
            CreateMap<ColorUpdateDto, Color>();
            CreateMap<ColorDto, Color>();
        }
    }
}
