using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Infrastructure.Data;
using API.Errors;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
         private readonly StoreContext _context;
        public BuggyController(StoreContext context){
           _context = context;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest(){
            var thing = _context.Products.Find(41);
            if(thing == null){
                return NotFound( new ApiResponse(404));
            }
           return Ok();
        }

          [HttpGet("servererror")]
        public ActionResult GetServerError(){
            var thing = _context.Products.Find(42);
            var thins = thing.ToString();
           return Ok();
        }


          [HttpGet("badrequest")]
        public ActionResult GetBadRequest(){
           return BadRequest( new ApiResponse(400));
        }



          [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id){
           return Ok();
        }
    }
}