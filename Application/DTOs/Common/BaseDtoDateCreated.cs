using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common
{
    public abstract class BaseDtoDateCreated
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
