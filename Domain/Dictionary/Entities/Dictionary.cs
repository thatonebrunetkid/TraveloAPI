using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.DictionaryWord.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dictionary.Entities
{
    public class Dictionary
    {
        [Key]
        public int DictionaryId { get; set; }
        public string Name { get; set; }
        public List<DictionaryWord.Entities.DictionaryWord> Words { get; set; }
    }
}
