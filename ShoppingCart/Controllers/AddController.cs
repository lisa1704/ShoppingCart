using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Database;
using ShoppingCart.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCart.Controllers
{
    [Route("api/cart/add/{itemName}")]
    [ApiController]
    public class AddController : ControllerBase
    {
        DatabaseContext db;
        public AddController()
        {
            db = new DatabaseContext();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cart model)
        {
            try
            {
                if (db.carts.Any(c => c.itemName == model.itemName))
                {
                    Cart thisCart = db.carts.Find(model.itemName);
                    thisCart.itemName = model.itemName;
                    db.carts.Update(thisCart);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status202Accepted);
                }

                else
                {
                    db.carts.Add(model);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created, model); //1id On success, return HTTP 201

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex); //1ic for other errors, return HTTP 500
            }
        }


        

    }

}

