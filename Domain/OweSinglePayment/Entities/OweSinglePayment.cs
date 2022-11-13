using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OweSinglePayment.Entities
{
    public class OweSinglePayment
    {
        [Key]
        public int OweSinglePaymentId { get; set; }
        public string PersonName { get; set; }
        public Decimal PaymentAmount { get; set; }
        public bool PaymentStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool IsPayer { get; set; }
        public int ExpenseId { get; set; }
    }
}
