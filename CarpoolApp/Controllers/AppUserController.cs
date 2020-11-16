using CarpoolApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Controllers
{
    public class AppUserController : BaseApiController
    {
        private readonly DBContext _context;
        public AppUserController(DBContext context)
        {
            _context = context;
        }

        [EnableCors("GlobalPolicy")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserInfo(long id)
        {
            return await _context.AppUser.FindAsync(id);
        }

        [EnableCors("GlobalPolicy")]
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(string username, string password, string name, string email, long phoneNumber)
        {
            //Hashing algorithm
            //using keyword to dispose hmac correctly
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                Username = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
                Email = email,
                Name = name,
                PhoneNumber = phoneNumber
            };

            _context.AppUser.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
