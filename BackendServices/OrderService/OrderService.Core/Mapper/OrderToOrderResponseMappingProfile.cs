using AutoMapper;
using OrderService.Core.DTOs;
using OrderService.Core.Entities;

namespace OrderService.Core.Mapper;

public class OrderToOrderResponseMappingProfile : Profile
{
    public OrderToOrderResponseMappingProfile()
    {
        CreateMap<Orders,OrderResponseDto>();
    }
}
