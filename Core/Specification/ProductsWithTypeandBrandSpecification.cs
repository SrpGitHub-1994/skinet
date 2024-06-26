using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypeandBrandSpecification:BaseSpecification<Product>
    {
        public ProductsWithTypeandBrandSpecification()
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=> x.ProductType);
        }

        public ProductsWithTypeandBrandSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=> x.ProductType);
        }
    }
}