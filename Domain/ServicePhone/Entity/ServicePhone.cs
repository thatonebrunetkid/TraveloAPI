using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServicePhone.Entity
{
    public class ServicePhone
    {
        [Key]
        public int ServicePhoneId { get; set; }
        public int Number { get; set; }
    }
}
