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
       private readonly IProductRepo _repo;
    public ProductsController(IProductRepo repo){
     _repo = repo;
    }
    [HttpGet]
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetMe(){
            // execute a select query

            var products = await _repo.GetProductsAsync() ;
            return Ok(products);
        }
        [HttpGet ("{id}")]
        public async Task<ActionResult<List<Product>>> GetMe( int id){
         
         var ProductId=  await _repo.GetProductByIdAsync(id);
         return Ok(ProductId);
        }
    }
}