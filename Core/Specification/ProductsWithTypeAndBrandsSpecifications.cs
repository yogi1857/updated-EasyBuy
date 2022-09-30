using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrandsSpecification(ProductSpecPrams productPrams)
        :base(x => 
        (string.IsNullOrEmpty(productPrams.Search) || x.Name.ToLower().Contains(productPrams.Search)) &&
        (!productPrams.BrandId.HasValue || x.ProductBrandId == productPrams.BrandId) &&(!productPrams.TypeId.HasValue || x.ProductTypeId == productPrams.TypeId)
        
        )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.productBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productPrams.PageSize*(productPrams.PageIndex -1),productPrams.PageSize);
                 
            if(!string.IsNullOrEmpty(productPrams.Sort)){
               
               switch(productPrams.Sort)
               {
                  case "priceAsc":
                  AddOrderBy(p => p.Price);
                  break;

                  case "priceDesc" :
                  AddOrderByDecending(p => p.Price);
                  break;

                  default :
                  AddOrderBy( n => n.Name);
                  break;


               }



            }


        }
        public ProductsWithTypeAndBrandsSpecification(int id):base(x => x.Id == id){
             AddInclude(x => x.ProductType);
             AddInclude(x => x.productBrand);
        }
    }
}