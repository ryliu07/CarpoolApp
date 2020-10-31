using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Models
{
    public class CarPost
    {
        public long Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public List<string> Dropoff { get; set; }
        public DateTime DimeBegin { get; set; }
        public DateTime DimeEnd { get; set; }
        public int Dccupancy { get; set; }
        public int Luggage { get; set; }
        public string Note { get; set; }

    }
}
