using FastFood.Domain.Entities;

namespace FastFood.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
    }
}
