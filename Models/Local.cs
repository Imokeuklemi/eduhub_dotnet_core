using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Local
    {
        public Local()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
