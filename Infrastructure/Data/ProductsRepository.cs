using Core;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class Productsrepository : IProductRepository
    {
        public StoreContext Context { get; set; }
        public Productsrepository(StoreContext context)
        {
            this.Context = context;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await this.Context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
           return await this.Context.Products
           .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
           .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandAsync()
        {
            return await this.Context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductsTypeAsync()
        {
          return await this.Context.ProductTypes.ToListAsync();
        }
    }
}