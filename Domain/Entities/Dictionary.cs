using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dictionary
    {
        [Key]
        public int DictionaryId { get; set; }
        public string Name { get; set; }
        public List<DictionaryWord> Words { get; set; }
    }
}
