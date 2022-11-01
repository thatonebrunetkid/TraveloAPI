using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DictionaryWord.DTO
{
    public class GetDictionaryWordsDTO
    {
        [JsonPropertyName("polish")]
        public string Word { get; set; }
        [JsonPropertyName("translate")]
        public string WordTranslated { get; set; }
    }
}
