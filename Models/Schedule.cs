using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Schedule
    {
        public short Id { get; set; }
        public string Purpose { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}
