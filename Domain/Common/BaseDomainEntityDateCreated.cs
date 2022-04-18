using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseDomainEntityDateCreated
    {
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
