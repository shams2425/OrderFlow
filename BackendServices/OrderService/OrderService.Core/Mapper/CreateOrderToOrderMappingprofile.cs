using AutoMapper;
using OrderService.Core.Entities;
using OrderService.Core.DTOs;

namespace OrderService.Core.Mappers
{
    public class CreateOrderToOrderMappingprofile : Profile
    {
        public CreateOrderToOrderMappingprofile()
        {
                 CreateMap<CreateOrderDto, Orders>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Price * src.Quantity));
        }
    }
}