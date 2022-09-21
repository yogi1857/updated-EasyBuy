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

namespace API.Controllers

{
 

    [ApiController] 
[Route("api/[controller]")]
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class ProductsController : ControllerBase
    {
       private readonly IGenericRepository<Product> _productRepo;
       private readonly IGenericRepository<ProductBrand> _productBrandRepo;
       private readonly IGenericRepository<ProductTyp> _productTypeRepo;

    public ProductsController(IGenericRepository<Product> productRepo,IGenericRepository<ProductBrand>productBrandRepo,IGenericRepository<ProductTyp> productTypeRepo){
    _productRepo = productRepo;
    _productBrandRepo = productBrandRepo;
    _productTypeRepo = productTypeRepo;
    }
    [HttpGet]
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct(){
            // execute a select query

            var products = await _productRepo.ListAllAsync();
            return Ok(products);
        }
        [HttpGet ("{id}")]
        public async Task<ActionResult<List<Product>>> GetProduct( int id){
         
         var ProductId=  await _productRepo.GetByIdAsync(id);
         return Ok(ProductId);
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