using FastFood.Application.Interfaces.Services;
using FastFood.Domain.Entities;
using FastFood.Domain.Interfaces.Repositories;

namespace FastFood.Application.Services
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public Task AddOrder(Order order)
        {
            return _orderRepository.AddOrderAsync(order);
        }
    }
}
