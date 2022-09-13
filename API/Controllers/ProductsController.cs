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

namespace API.Controllers

{
 

    [ApiController] 
[Route("api/[controller]")]
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class ProductsController : ControllerBase
    {
private readonly StoreContext _context;
    public ProductsController(StoreContext context){
     _context = context;
    }
    [HttpGet]
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetMe(){
            // execute a select query

            var products = await _context.Products.ToListAsync() ;
            return Ok(products);
        }
        [HttpGet ("{id}")]
        public async Task<ActionResult<List<Product>>> GetMe( int id){
         
         var ProductId=  await _context.Products.FindAsync(id);
         return Ok(ProductId);
        }
    }
}