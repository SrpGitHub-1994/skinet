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
        public ProductsWithTypeandBrandSpecification(string sort)
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=> x.ProductType);
            AddOrderBy(x=>x.ProductName);

            if (sort != null)
            {
                switch (sort)
                {
                    case "priceasc": AddOrderBy(x=>x.Price); 
                    break;
                    case "pricedesc": AddOrderByDesc(x=>x.Price);
                    break;
                    default: AddOrderBy(x=>x.ProductName);
                    break;
                }
            }
        }

        public ProductsWithTypeandBrandSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=> x.ProductType);
               AddOrderBy(x=>x.ProductName);
        }
    }
}