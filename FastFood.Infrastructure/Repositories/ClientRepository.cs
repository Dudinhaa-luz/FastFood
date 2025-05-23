using FastFood.Domain.Entities;
using FastFood.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infrastructure.Repositories
{
    public class ClientRepository(AppDbContext context) : IClientRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
