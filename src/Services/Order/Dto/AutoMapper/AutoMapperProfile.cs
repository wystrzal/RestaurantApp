using AutoMapper;
using Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Dto.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrderItemForAddDto, OrderItem>();

            CreateMap<OrderForAddWorkerDto, Orders>();

            CreateMap<OrderForAddClientDto, Orders>();
        }
    }
}
