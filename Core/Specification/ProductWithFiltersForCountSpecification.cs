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
         (!specificationparams.typeId.HasValue || x.ProdTypeId==specificationparams.typeId))
        {
            
        }
    }
}