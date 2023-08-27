
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private StoreContext _Sdb { get; }
        public ProductsController(StoreContext sdb)
        {
            _Sdb = sdb;
        }
        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _Sdb.Products.ToListAsync();
        }

        [HttpGet("GetProduct/{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            return await _Sdb.Products.FindAsync(Id);
        }
    }
}