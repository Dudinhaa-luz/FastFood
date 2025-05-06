using FastFood.Domain.Entities;

namespace FastFood.Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task AddClient(Client client);
    }
}
