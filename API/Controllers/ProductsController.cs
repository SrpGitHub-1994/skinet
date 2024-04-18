
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;


namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        public IGenericRepository<Product> Repo { get; }
        public IGenericRepository<ProductBrand> RepoBrand { get; }
        public IGenericRepository<ProductType> RepoType { get; }

        public ProductsController(IGenericRepository<Product> _repo,
        IGenericRepository<ProductBrand> _repoBrand,
        IGenericRepository<ProductType> _repoType)
        {
            Repo = _repo;
            RepoBrand = _repoBrand;
            RepoType = _repoType;
        }
        [HttpGet("Products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var ProdList= await Repo.GetAllAsync();

            return Ok(ProdList);
        }

        [HttpGet("Product/{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            var prod= await Repo.GetByIdAsync(Id);
            return Ok(prod);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var prod= await Repo.GetAllAsync();
            return Ok(prod);
        }

         [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var prod= await Repo.GetAllAsync();
            return Ok(prod);
        }
    }
}