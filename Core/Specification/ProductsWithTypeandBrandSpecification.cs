using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypeandBrandSpecification:BaseSpecification<Product>
    {
        public ProductsWithTypeandBrandSpecification(prodSpecificationparams specificationparams) : base(x=>
        (string.IsNullOrEmpty(specificationparams.Search) || x.ProductName.ToLower().Contains(specificationparams.Search)) &&
        (!specificationparams.brandId.HasValue || x.ProdBrandid==specificationparams.brandId) &&
        (string.IsNullOrEmpty(specificationparams.brands) || x.ProductBrand.Name.ToLower().Contains(specificationparams.brands)) &&
        (string.IsNullOrEmpty(specificationparams.types) || x.ProductType.Name.ToLower().Contains(specificationparams.types)) &&
         (!specificationparams.typeId.HasValue || x.ProdTypeId==specificationparams.typeId)
        )
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=> x.ProductType);              

            if (specificationparams.sort != null)
            {
                switch (specificationparams.sort)
                {
                    case "priceAsc": AddOrderBy(x=>x.Price); 
                    break;
                    case "priceDesc": AddOrderByDesc(x=>x.Price);
                    break;
                    default: AddOrderBy(x=>x.ProductName);
                    break;
                }
            }
            else{
                 AddOrderBy(x=>x.ProductName);
            }
            
             ApplyPaging(specificationparams.PageSize*((specificationparams.pageIndex)-1), specificationparams.PageSize);
        
        }

        public ProductsWithTypeandBrandSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=> x.ProductType);
        }
    }
}