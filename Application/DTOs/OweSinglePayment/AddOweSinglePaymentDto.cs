using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OweSinglePayment
{
    public class AddOweSinglePaymentDto
    {
        public string PersonName { get; set; }
        public Decimal PaymentAmount { get; set; }
        public bool PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPayer { get; set; }
    }
}
