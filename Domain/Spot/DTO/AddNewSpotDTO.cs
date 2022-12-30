using Domain.Expense.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Spot.DTO
{
    public class AddNewSpotDTO
    {
        public string? Note { get; set; }
        [JsonPropertyName("Address")]
        public string? Adress { get; set; }
        [JsonPropertyName("lan")]
        public Decimal? CoordinateX { get; set; }
        [JsonPropertyName("lat")]
        public Decimal? CoordinateY { get; set; }
        public string? Name { get; set; }
        public AddNewExpenseDTO? Expense { get; set; }
    }
}
