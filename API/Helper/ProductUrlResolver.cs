using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using API.DTO;
using Microsoft.Extensions.Configuration;

namespace API.Helper
{
    public class ProductUrlResolver : IValueResolver<Product,ProductToReturn,string>

    {
        private readonly IConfiguration _config;
        public ProductUrlResolver( Microsoft.Extensions.Configuration.IConfiguration  config){
           _config = config;
        }
        public string Resolve(Product source,ProductToReturn destination,string destMember,ResolutionContext context)
        {
         if(!string.IsNullOrEmpty(source.PictureUrl)){
            return _config["ApiUrl"]+source.PictureUrl; 
         }
         return null;       
        }
    }
}