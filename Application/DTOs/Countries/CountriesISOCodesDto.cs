using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Countries
{
    public class CountriesISOCodesDto
    {
        [JsonPropertyName("Code")]
        public string CodeABC { get; set; }
    }
}
