using FastFood.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : Repository<Product>(context), IProductRepository
    {
        public async Task<Product?> GetByCodeAsync(string code)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string namePart)
        {
            return await _context.Products.Where(x => x.Name.Contains(namePart)).ToListAsync();
        }
    }
}
