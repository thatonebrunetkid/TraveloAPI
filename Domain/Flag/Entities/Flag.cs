using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Flag.DTO
{
    public class Flag
    {
        [Key]
        public int FlagId { get; set; }
        public string URL { get; set; }
    }
}
