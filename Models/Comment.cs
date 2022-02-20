using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string CommentBody { get; set; } = null!;
        public string Username { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? PostId { get; set; }
    }
}
