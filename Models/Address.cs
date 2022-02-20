using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Street { get; set; } = null!;
        public int Lg { get; set; }
        public string ContactPhone { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
