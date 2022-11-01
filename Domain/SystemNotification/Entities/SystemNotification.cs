using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SystemNotification.Entities
{
    public class SystemNotification
    {
        [Key]
        public int SystemNotificationId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidDate { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
