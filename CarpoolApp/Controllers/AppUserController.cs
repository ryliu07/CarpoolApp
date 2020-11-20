using CarpoolApp.DTOs;
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
        public async Task<ActionResult<AppUser>> Register(RegisterDto regDto)
        {
            //Hashing algorithm
            //using keyword to dispose hmac correctly
            if (await EmailExists(regDto.Email)) return BadRequest("Email is already in use");

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                Email = regDto.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(regDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.AppUser.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.AppUser.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}
