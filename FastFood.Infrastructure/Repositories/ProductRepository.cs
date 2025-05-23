using FastFood.Domain.Entities;
using FastFood.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(EnumCategoryProduct categoryProduct)
        {
            return await _context.Products.Where(category => category.Category == categoryProduct).ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

    }
}
