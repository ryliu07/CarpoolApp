﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.DTOs
{
    public class RegisterDto
    {
        //System.ComponentModel.DataAnnotations validation attributes
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
