using CarpoolApp.DTOs;
using CarpoolApp.Interfaces;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ITokenService _tokenService;
        public AppUserController(DBContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [EnableCors("GlobalPolicy")]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AppUser>> GetUserInfo(long id)
        {
            return await _context.AppUser.FindAsync(id);
        }

        [EnableCors("GlobalPolicy")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.AppUser
                .SingleOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null) return Unauthorized("User does not exist");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        [EnableCors("GlobalPolicy")]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto regDto)
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

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
       
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.AppUser.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}
