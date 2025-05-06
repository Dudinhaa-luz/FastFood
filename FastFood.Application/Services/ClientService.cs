using FastFood.Domain.Entities;
using FastFood.Application.Interfaces.Services;
using FastFood.Domain.Interfaces.Repositories;

namespace FastFood.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public Task AddClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
