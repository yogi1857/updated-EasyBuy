using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrandsSpecification(string sort,int? brandId,int? typeId):base(x => 
        (!brandId.HasValue || x.ProductBrandId == brandId) &&(!typeId.HasValue || x.ProductTypeId == typeId)
        
        )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.productBrand);
            AddOrderBy(x => x.Name);
                 
            if(!string.IsNullOrEmpty(sort)){
               
               switch(sort)
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