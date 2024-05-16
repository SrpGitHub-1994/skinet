
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;
using System.Diagnostics;
using Core.Specification;
using API.Dtos;
using AutoMapper;


namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        public IGenericRepository<Product> Repo { get; }
        public IGenericRepository<ProductBrand> RepoBrand { get; }
        public IGenericRepository<ProductType> RepoType { get; }
        public IMapper Mapper { get; }

        public ProductsController(IGenericRepository<Product> _repo,
        IGenericRepository<ProductBrand> _repoBrand,
        IGenericRepository<ProductType> _repoType,IMapper mapper)
        {
            this.Mapper = mapper;
            Repo = _repo;
            RepoBrand = _repoBrand;
            RepoType = _repoType;
        }
        [HttpGet("Products")]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            var spec=new ProductsWithTypeandBrandSpecification();
            var ProdList= await Repo.ListAsync(spec);

            return Ok(ProdList.Select(prod=>new ProductDTO {
            Id=prod.Id,
            ProductBrand=prod.ProdBrandid.ToString(),//RepoBrand.GetByIdAsync(prod.ProdBrandid).Result.Name,
            ProductType=prod.ProdBrandid.ToString(),//RepoType.GetByIdAsync(prod.ProdBrandid).Result.Name,
            Description=prod.Description,
            PictureUrl=prod.PictureUrl,
            ProductName=prod.ProductName,
            Price=prod.Price

           }).ToList());
        }

        [HttpGet("Product/{Id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int Id)
        {
            var spec=new ProductsWithTypeandBrandSpecification();
            var prod= await Repo.GetEntityWithSpec(spec);
            prod.ProductBrand=RepoBrand.GetByIdAsync(prod.ProdBrandid).Result;
            prod.ProductType=RepoType.GetByIdAsync(prod.ProdTypeId).Result;
           return Ok(Mapper.Map<Product,ProductDTO>(prod));
        
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