using FastFood.Domain.Enums;

namespace FastFood.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task<Product?> GetByIdAsync(Guid Id);
        Task<IEnumerable<Product>> GetAllProducts(EnumCategoryProduct categoryProduct);
        Task<Product?> UpdateProduct(Product product);
        Task RemoveProduct(Product product);
    }
}
