using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using System.Collections.Generic;
using Core.Entities;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specification;
using API.DTO;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;
namespace API.Controllers

{
 

  
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class ProductsController : BaseApiController
    {
       private readonly IGenericRepository<Product> _productRepo;
       private readonly IGenericRepository<ProductBrand> _productBrandRepo;
       private readonly IGenericRepository<ProductTyp> _productTypeRepo;
        private readonly IMapper _mapper;

    public ProductsController(IGenericRepository<Product> productRepo,IGenericRepository<ProductBrand>productBrandRepo,IGenericRepository<ProductTyp> productTypeRepo,IMapper mapper){
    _productRepo = productRepo;
    _productBrandRepo = productBrandRepo;
    _productTypeRepo = productTypeRepo;
    _mapper = mapper;
    }
    [HttpGet]
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturn>>> GetProduct([FromQuery]ProductSpecPrams productprams){
            // execute a select query
               var spec = new ProductsWithTypeAndBrandsSpecification(productprams);
            var products = await _productRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturn>> (products));
        }
        [HttpGet ("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturn>> GetProduct( int id){
          var spac = new ProductsWithTypeAndBrandsSpecification(id);
         var product = await _productRepo.GetEntityWithSpec(spac);
         if(product == null) return NotFound(new ApiResponse(404));
       return _mapper.Map<Product,ProductToReturn>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrand(){
            return Ok(await _productBrandRepo.ListAllAsync());
        } 

           [HttpGet("types")]
        public async Task<ActionResult<List<ProductTyp>>> GetProductType(){
            return Ok(await _productTypeRepo.ListAllAsync()); 
        } 
    }
}