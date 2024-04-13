using System.Text.Json;
using System.Text.Json.Nodes;
using Core.Entities;

namespace Infrastructure.Data
{
    public class ContextSeedData
    {
        public static async Task CreateContextSeedData(StoreContext context)
        {
            string seedpath="../Infrastructure/Data/SeedData/";
           if (!context.ProductBrands.Any())
           {
             var brands=File.ReadAllText(seedpath+"brands.json");
            var prodBrands=JsonSerializer.Deserialize<List<ProductBrand>>(brands);  
            context.ProductBrands.AddRange(prodBrands);

           }

           if (!context.ProductTypes.Any())
           {
            var brands=File.ReadAllText(seedpath+"types.json");
            var prodBrands=JsonSerializer.Deserialize<List<ProductType>>(brands);  
            context.ProductTypes.AddRange(prodBrands);

           }

            if (!context.Products.Any())
           {
             var brands=File.ReadAllText(seedpath+"products.json");
            var prodBrands=JsonSerializer.Deserialize<List<Product>>(brands);  
            context.Products.AddRange(prodBrands);
            
           }
            if(context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}