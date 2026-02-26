using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SimpleProductApplication.Application.Interfaces;
using SimpleProductApplication.Domain.Entities;

namespace SimpleProductApplication.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository) => _repository = repository;

        public Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default)
            => _repository.GetAllAsync(ct);

        public Task<Product?> GetByIdAsync(int id, CancellationToken ct = default)
            => _repository.GetByIdAsync(id, ct);

        public Task CreateAsync(Product product, CancellationToken ct = default)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));
            return _repository.AddAsync(product, ct);
        }

        public Task UpdateAsync(Product product, CancellationToken ct = default)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));
            return _repository.UpdateAsync(product, ct);
        }

        public Task DeleteAsync(int id, CancellationToken ct = default) => _repository.DeleteAsync(id, ct);
    }
}