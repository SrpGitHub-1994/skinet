
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;
using System.Diagnostics;
using Core.Specification;
using API.Dtos;
using AutoMapper;
using API.Errors;
using API.Helpers;


namespace API.Controllers
{
    public class ProductsController : BaseAPIController
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
        [ProducesResponseType(StatusCodes.Status200OK)]
       // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<ProductDTO>>> GetProducts([FromQuery] prodSpecificationparams specificationparams)
        {
            var spec=new ProductsWithTypeandBrandSpecification(specificationparams);

            var CountSpec=new ProductWithFiltersForCountSpecification(specificationparams);

            var totalItems= await Repo.GetCountAsync(CountSpec);

            var ProdList= await Repo.ListAsync(spec);

            var retData=Mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDTO>>(ProdList);

            return Ok(new Pagination<ProductDTO> (specificationparams.pageIndex,specificationparams.PageSize,totalItems,retData));
        }

        [HttpGet("Product/{Id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int Id)
        {
            var spec=new ProductsWithTypeandBrandSpecification(Id);
            var prod= await Repo.GetEntityWithSpec(spec);
            prod.ProductBrand=RepoBrand.GetByIdAsync(prod.ProdBrandid).Result;
            prod.ProductType=RepoType.GetByIdAsync(prod.ProdTypeId).Result;
           return Ok(Mapper.Map<Product,ProductDTO>(prod));
        
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands= await RepoBrand.GetAllAsync();
            return Ok(brands);
        }

         [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var typ= await RepoType.GetAllAsync();
            return Ok(typ);
        }
    }
}