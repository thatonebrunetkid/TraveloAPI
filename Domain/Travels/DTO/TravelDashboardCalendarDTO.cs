using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Travels.DTO
{
    public class TravelDashboardCalendarDTO
    {
        [JsonPropertyName("Title")]
        public string Destination { get; set; }
        public bool allDay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
