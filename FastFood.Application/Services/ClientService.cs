using FastFood.Domain.Entities;
using FastFood.Application.Interfaces.Services;
using FastFood.Domain.Interfaces.Repositories;

namespace FastFood.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

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
