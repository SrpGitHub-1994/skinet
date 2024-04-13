
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public IProductRepository Repo { get; }

        public ProductsController(IProductRepository repo)
        {
            Repo = repo;
        }
        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var ProdList= await Repo.GetProductsAsync();

            return Ok(ProdList);
        }

        [HttpGet("GetProduct/{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            var prod= await Repo.GetProductAsync(Id);
            return Ok(prod);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var prod= await Repo.GetProductsBrandAsync();
            return Ok(prod);
        }

         [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var prod= await Repo.GetProductsTypeAsync();
            return Ok(prod);
        }
    }
}