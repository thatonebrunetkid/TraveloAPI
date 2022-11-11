using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OweSinglePayment.DTO
{
    public class AddNewOweSinglePaymentDTO
    {
        public string PersonName { get; set; }
        public Decimal PaymentAmount { get; set; }
        public bool PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPayer { get; set; }
    }
}
