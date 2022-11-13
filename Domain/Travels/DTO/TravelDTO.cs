using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Travels.DTO
{
    public class TravelDTO
    {
        public int TravelId { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FlagURL { get; set; }
    }
}
