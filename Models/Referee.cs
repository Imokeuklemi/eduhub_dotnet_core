using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Referee
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public string Org { get; set; } = null!;
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public string? Relationship { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
