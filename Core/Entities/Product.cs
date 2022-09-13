using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
         public string  Name { get; set; }
         public  string Decryption{get;set;}
         public decimal Price{get; set;}
          public string PictureUrl{get;set;}
           public ProductTyp ProductType{get;set;}
            public ProductBrand productBrand {get;set;}
            public int ProductBrandId{get;set;}

        
    }
}