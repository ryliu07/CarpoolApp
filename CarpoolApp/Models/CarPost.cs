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
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Occupancy { get; set; }
        public int Luggage { get; set; }
        public string Note { get; set; }

        //TODO - Poster ID, Booker ID, etc

    }
}
