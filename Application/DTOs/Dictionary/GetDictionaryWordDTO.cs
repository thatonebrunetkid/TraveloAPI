using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Dictionary
{
    public class GetDictionaryWordDTO
    {
        [JsonPropertyName("polish")]
        public string Word { get; set; }
        [JsonPropertyName("translate")]
        public string WordTranslated { get; set; }
    }
}
