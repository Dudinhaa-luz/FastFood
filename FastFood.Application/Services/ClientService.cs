using FastFood.Application.Interfaces.Services;
using FastFood.Domain.Entities;
using FastFood.Domain.Interfaces.Repositories;

namespace FastFood.Application.Services
{
    public class ClientService(IClientRepository clientRepository) : IClientService
    {
        private readonly IClientRepository _clientRepository = clientRepository;

        public Task AddClient(Client client)
        {
            return _clientRepository.AddClient(client);
        }

        public Task<IEnumerable<Client>> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }
    }
}
