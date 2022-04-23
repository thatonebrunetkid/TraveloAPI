using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Alerts
{
    public class AlertDto
    {
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
