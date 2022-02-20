using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public int? MobileNumber { get; set; }
        public string? EmailVerified { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
