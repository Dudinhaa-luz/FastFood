using AutoMapper;
using FastFood.Application.DTOs;
using FastFood.Application.Interfaces.Services;
using FastFood.Application.Validators;
using FastFood.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var validationResult = new CreateOrderRequestValidator().Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var order = _mapper.Map<Order>(request);
            await _orderService.AddOrder(order);

            return Ok();
        }
    }
}
