using FastFood.Application.Interfaces.Services;
using FastFood.Domain.Entities;
using FastFood.Domain.Interfaces.Repositories;

namespace FastFood.Application.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {

        private readonly IProductRepository _productRepository = productRepository;

        public async Task AddProduct(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }

        public async Task<Product?> GetByIdAsync(Guid Id)
        {
            return await _productRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts(EnumCategoryProduct categoryProduct)
        {
            return await _productRepository.GetAllProductsByCategoryAsync(categoryProduct);
        }

        public async Task RemoveProduct(Product product)
        {
            await _productRepository.DeleteAsync(product);
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            var existing = await GetByIdAsync(product.Id);

            if (existing is null)
                return null;

            existing.Code = product.Code;
            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.Category = product.Category;

            await _productRepository.UpdateProductAsync(existing);

            return existing;
        }
    }
}
