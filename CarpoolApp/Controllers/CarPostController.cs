using CarpoolApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Controllers
{
    public class CarPostController : BaseApiController
    { 
        private readonly DBContext _context;
        public CarPostController(DBContext context)
        {
            _context = context;
        }

        [EnableCors("GlobalPolicy")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CarPost>>> GetCarPosts()
        {
            Console.WriteLine("hi");
            return await _context.CarPost.ToListAsync();
        }

        [EnableCors("GlobalPolicy")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CarPost>> GetCarPostFromID(long id)
        {
            return await _context.CarPost.FindAsync(id);
        }
    }
}
