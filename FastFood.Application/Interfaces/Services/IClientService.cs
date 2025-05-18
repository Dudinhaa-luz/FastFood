using FastFood.Domain.Entities;

namespace FastFood.Application.Interfaces.Services
{
    public interface IClientService
    {
        Task AddClient(Client client);
        Task<IEnumerable<Client>> GetAllClients();
    }
}
