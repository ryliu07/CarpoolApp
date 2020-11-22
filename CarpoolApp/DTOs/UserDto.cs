using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.DTOs
{
    public class UserDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
