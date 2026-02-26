using SimpleProductApplication.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleProductApplication.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Product product, CancellationToken ct = default);
        Task UpdateAsync(Product product, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
    }
}