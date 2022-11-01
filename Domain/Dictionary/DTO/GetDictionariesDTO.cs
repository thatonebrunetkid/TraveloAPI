using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dictionary.DTO
{
    public class GetDictionariesDTO
    {
        [JsonPropertyName("language")]
        public List<GetDictionaryDTO> Dictionaries { get; set; }
    }
}
