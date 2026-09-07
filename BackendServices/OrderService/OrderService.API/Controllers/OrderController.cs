using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using OrderService.Core.Entities;
using OrderService.Core.Interfaces;
using OrderService.Core.DTOs;
using OrderService.Core.Events;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEventPublisher _eventPublisher;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper, IEventPublisher eventPublisher)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _eventPublisher = eventPublisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            Orders order = _mapper.Map<Orders>(dto);
            Orders created = await _orderRepository.CreateOrderAsync(order);

           OrderPlacedEvent orderPlacedEvent = _mapper.Map<OrderPlacedEvent>(created);
           await _eventPublisher.Publish(orderPlacedEvent, "order-placed-queue");

            return Ok(_mapper.Map<OrderResponseDto>(created));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            return Ok(_mapper.Map<OrderResponseDto>(order));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrderAsync();
            return Ok(_mapper.Map<IEnumerable<OrderResponseDto>>(orders));
        }
    }
}