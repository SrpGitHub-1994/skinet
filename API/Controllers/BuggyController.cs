using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController:BaseAPIController
    {

        public BuggyController(StoreContext storeContext)
        {
            StoreContext = storeContext;
        }

        public StoreContext StoreContext { get; }

        [HttpGet("notfound")]   
        public IActionResult GetNotFound()
        {
            var thing=StoreContext.Products.Find(42);
            if(thing==null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("servererror")]   
        public IActionResult Getservererror()
        {
             var thing=StoreContext.Products.Find(55);
             var transformThing=thing.ToString();


            return Ok();
        }

        [HttpGet("badrequest")]   
        public IActionResult Getbadrequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]   
        public IActionResult GetNotFound(int id)
        {
            return Ok();
        }
    }
}