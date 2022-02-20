using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Credential
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string FileType { get; set; } = null!;
        public byte[] DataFiles { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
