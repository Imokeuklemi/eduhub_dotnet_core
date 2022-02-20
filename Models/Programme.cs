using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Programme
    {
        public Programme()
        {
            DeptProgs = new HashSet<DeptProg>();
        }

        public int Id { get; set; }
        public string? ProgName { get; set; }
        public string Department { get; set; } = null!;

        public virtual ICollection<DeptProg> DeptProgs { get; set; }
    }
}
