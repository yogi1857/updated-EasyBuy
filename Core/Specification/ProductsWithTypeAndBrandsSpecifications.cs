using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.productBrand);
        }
        public ProductsWithTypeAndBrandsSpecification(int id):base(x => x.Id == id){
             AddInclude(x => x.ProductType);
             AddInclude(x => x.productBrand);
        }
    }
}