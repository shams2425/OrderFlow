using AutoMapper;
using OrderService.Core.Entities;
using OrderService.Core.Events;

namespace OrderService.Core.Mapper;

public class OrderToOrderPlacedEventMappingProfile : Profile
{
    public OrderToOrderPlacedEventMappingProfile()
    {
        CreateMap<Orders, OrderPlacedEvent>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id));
        
    }
}
