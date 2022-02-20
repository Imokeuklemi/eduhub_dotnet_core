using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public string Txref { get; set; } = null!;
        public string TransactionId { get; set; } = null!;
        public string Payer { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public int Amount { get; set; }
        public int StudentId { get; set; }
        public DateTime Ddate { get; set; }
        public string PaymentStatus { get; set; } = null!;
        public string Purpose { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
