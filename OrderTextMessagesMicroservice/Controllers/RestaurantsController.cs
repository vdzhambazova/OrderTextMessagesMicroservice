using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OrderTextMessagesMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private static readonly Restaurant[] Restaurants = new[]
        {
            new Restaurant(1, "Pizza Lab", "italian", "ul Graf Ingatiev", "10 min"),
            new Restaurant(2, "Hummus bar", "israeli", "bul Vasil Levski", "20 min"),
            new Restaurant(3, "Mr Pizza", "bulgarian", "ul Graf Ingatiev", "40 min"),
            new Restaurant(4, "Hao Tag Yan", "chinese", "ul Cherkovna", "60 min"),
            new Restaurant(5, "Made in Blue", "modern", "ul Yuri Venelin", "10 min"),
            new Restaurant(6, "Ashurbanipal", "middle eastern", "bul Knyaz Boris", "75 min")
        };


        // GET: api/<RestaurantsController>
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> Get()
        {
            return Ok(Restaurants);
        }
    }
}
