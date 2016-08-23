using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MyMovies.Models;
using System.Threading.Tasks;
using ServiceStack.Common;


namespace MyMovies.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly RedisContext context;

        public MoviesController()
        {
            context = new RedisContext();
        }

        [HttpGet]
        public List<Movie> Get()
        {
            return context.GetMovies();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(context.GetMovie(id));
        }
    }
}
