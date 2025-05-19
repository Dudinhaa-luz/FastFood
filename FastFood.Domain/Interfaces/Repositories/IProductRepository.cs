using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFood.Domain.Entities;

namespace FastFood.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetByCodeAsync(string code);
        Task<IEnumerable<Product>> SearchByNameAsync(string namePart);
    }
}
