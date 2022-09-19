using System;
namespace Application.DTOs.Payment
{
    public class PaymentDTO
    {
        public int UserID { get; set; }
        public string TargetPhoneNumber { get; set; }
        public string BlikCode { get; set; }
        public bool CorrectionFlag { get; set; }
    }
}

