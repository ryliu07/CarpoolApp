using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarPostController : ControllerBase
    {
        private readonly CarPostContext _context;
        public CarPostController(CarPostContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarPost>> GetCarPosts()
        {
            Console.WriteLine("Hi");
            return _context.CarPost.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CarPost> GetCarPost(long id)
        {
            return _context.CarPost.Find(id);
        }
    }
}
