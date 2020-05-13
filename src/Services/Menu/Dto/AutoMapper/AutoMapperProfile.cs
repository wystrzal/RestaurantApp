using AutoMapper;
using Menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Dto.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MenuForAddItemDto, MenuItem>();

            CreateMap<MenuForAddTypeDto, MenuType>();

            CreateMap<MenuType, MenuForReturnTypesDto>();
        }
    }
}
