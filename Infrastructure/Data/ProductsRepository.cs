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
            return await this.Context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
           return await this.Context.Products.ToListAsync();
        }
    }
}