using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DictionaryWord.Entities
{
    public class DictionaryWord
    {
        [Key]
        public int DictionaryWordId { get; set; }
        public string Word { get; set; }
        public string WordTranslated { get; set; }
        public int DictionaryId { get; set; }
    }
}
