using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payment.DTO
{
    public class PaymentDTO
    {
        public int UserID { get; set; }
        public string TargetPhoneNumber { get; set; }
        public string BlikCode { get; set; }
        public bool CorrectionFlag { get; set; }
    }
}
