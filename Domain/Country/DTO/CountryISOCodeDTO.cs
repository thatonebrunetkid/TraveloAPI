using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Country.DTO
{
    public class CountryISOCodeDTO
    {
        [JsonPropertyName("Code")]
        public string CodeABC { get; set; }
    }
}
