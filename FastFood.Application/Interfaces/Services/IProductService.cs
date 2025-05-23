using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFood.Domain.Entities;

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
