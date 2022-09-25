using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using API.DTO;
namespace API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<Product,ProductToReturn>()
            .ForMember(d => d.productBrand , o=> o.MapFrom(s => s.productBrand.Name))
            .ForMember(d => d.ProductType , o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductUrlResolver>());
        }
    }
}