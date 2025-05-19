using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task<IEnumerable<Product>>GetAllProducts();
        Task<Product> UpdateProduct(Product product);
        Task RemoveProduct(Product product);
    }
}
