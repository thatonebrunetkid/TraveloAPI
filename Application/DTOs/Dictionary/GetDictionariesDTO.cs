using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Dictionary
{
    public class GetDictionariesDTO
    {
        [JsonPropertyName("language")]
        public List<GetDictionaryDTO> Dictionaries { get; set; }
    }
}
