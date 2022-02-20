using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public short Published { get; set; }
        public int? AuthorId { get; set; }

        public virtual Student? Author { get; set; }
    }
}
