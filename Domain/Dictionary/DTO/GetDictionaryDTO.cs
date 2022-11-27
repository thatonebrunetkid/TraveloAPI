using Domain.DictionaryWord.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dictionary.DTO
{
    public class GetDictionaryDTO
    {
        [JsonPropertyName("lang")]
        public string Name { get; set; }
        [JsonPropertyName("translation")]
        public List<GetDictionaryWordsDTO> Words { get; set; }
    }
}
