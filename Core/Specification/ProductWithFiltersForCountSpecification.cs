using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification :BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(prodSpecificationparams specificationparams ): base(x=>
       (string.IsNullOrEmpty(specificationparams.Search) || x.ProductName.ToLower().Contains(specificationparams.Search)) &&
        (!specificationparams.brandId.HasValue || x.ProdBrandid==specificationparams.brandId) &&
        (string.IsNullOrEmpty(specificationparams.brands) || x.ProductBrand.Name.ToLower().Contains(specificationparams.brands)) &&
        (string.IsNullOrEmpty(specificationparams.types) || x.ProductType.Name.ToLower().Contains(specificationparams.types)) &&
         (!specificationparams.typeId.HasValue || x.ProdTypeId==specificationparams.typeId))
        {
            
        }
    }
}