using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Travel
{
    public class GetTravelDatesFromCurrentMonthDto
    {
        [JsonPropertyName("Title")]
        public string Destination { get; set; }
        public bool AllDay { get; set; } = true;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
