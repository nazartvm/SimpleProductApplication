using Microsoft.EntityFrameworkCore;
using SimpleProductApplication.Application.Interfaces;
using SimpleProductApplication.Domain.Entities;
using SimpleProductApplication.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleProductApplication.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db) => _db = db;

        public async Task AddAsync(Product product, CancellationToken ct = default)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var e = await _db.Products.FindAsync(new object[] { id }, ct);
            if (e == null) return;
            _db.Products.Remove(e);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default)
            => await _db.Products.AsNoTracking().ToListAsync(ct);

        public async Task<Product?> GetByIdAsync(int id, CancellationToken ct = default)
            => await _db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);

        public async Task UpdateAsync(Product product, CancellationToken ct = default)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync(ct);
        }
    }
}