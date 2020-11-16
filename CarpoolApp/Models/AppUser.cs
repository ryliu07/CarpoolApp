using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Models
{
    public class AppUser
    {
        public long Id { get; set; }
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string PlateNumber { get; set; }

    }
}
