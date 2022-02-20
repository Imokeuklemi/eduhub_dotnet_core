using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Like
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
    }
}
