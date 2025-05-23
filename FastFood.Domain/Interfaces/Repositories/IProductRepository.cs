using FastFood.Domain.Enums;

namespace FastFood.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllProductsByCategoryAsync(EnumCategoryProduct categoryProduct);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
