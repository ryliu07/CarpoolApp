using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarpoolApp.Models
{
    public class CarPostContext : DbContext
    {
        public CarPostContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CarPost> CarPost { get; set; }
    }
}
