using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Country.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CodeABC { get; set; }
        public string CodeAB { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public int FlagId { get; set; }
        public int ServicePhoneId { get; set; }
    }
}
