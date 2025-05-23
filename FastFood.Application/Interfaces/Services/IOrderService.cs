using FastFood.Domain.Entities;

namespace FastFood.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task AddOrder(Order order);
    }
}
